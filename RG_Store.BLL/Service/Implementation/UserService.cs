using AutoMapper;
using Entities;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.Services.Implementation;
/*using RG_Store.BLL.ModelVM.UserVM;*/
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace RG_Store.BLL.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly CustomUserManager userManager;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;
        public UserService(CustomUserManager userManager, IMapper mapper, SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public bool CreateUser(RegisterVM registerVM, out string[] errors)
        {
            User user = mapper.Map<User>(registerVM);

            var result = userManager.CreateAsync(user, registerVM.Password).GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                errors = null;
                return true;
            }
            else
            {
                errors = result.Errors.Select(e => e.Description).ToArray();
                return false;
            }
        }

        public bool SignInUser(LoginVM model)
        {

            var result = signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SignoutUser()
        {
            signInManager.SignOutAsync();
        }

        public Task<User> FindByNameAsync(string? email)
        {
            return userManager.FindByNameAsync(email);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> UpdateUserAsync(EditUserVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                user.UserName = model.UserName;
                user.Email = model.Email;
                return await userManager.UpdateAsync(user);
            }

            return IdentityResult.Failed(new IdentityError { Description = "User not found" });
        }

        public async Task<IdentityResult> AddPasswordAsync(User user, string newPassword)
        {
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            return await userManager.AddPasswordAsync(user, newPassword);
        }

        public async Task<IdentityResult> RemovePasswordAsync(DeleteUserVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            return await userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string confirmationCode)
        {
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            return await userManager.ConfirmEmailAsync(user, confirmationCode);
        }

        public async Task<bool> SendConfirmationEmailAsync(string toEmail, string confirmationCode)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("RG_StoreProject@outlook.com", "123456789/."),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("RG_StoreProject@outlook.com"),
                    Subject = "Email Confirmation Code",
                    Body = $"Your email confirmation code is {confirmationCode}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}