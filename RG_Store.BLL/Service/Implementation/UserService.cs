using AutoMapper;
using Entities;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.Services.Implementation;
using Microsoft.AspNetCore.Identity;
using EmployeeSystem.DAL.Repo.Abstraction;
using RG_Store.DAL.Enums;
using System.Net.Mail;
using System.Net;

namespace RG_Store.BLL.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly CustomUserManager userManager;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;
        private readonly IUserRepo userRepo;
        public UserService(CustomUserManager userManager, IMapper mapper,SignInManager<User> signInManager, IUserRepo userRepo)
        {
            this.signInManager=signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.userRepo = userRepo;   
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

        public bool DeleteUser(DeleteUserVM model)
        {
            var user = mapper.Map<User>(model);
            return userRepo.DeleteUser(user);
        }

        public IEnumerable<GetUserVM> GetAll()
        {
           List<GetUserVM> result = new List<GetUserVM>();
            var temp = userRepo.GetAll().ToList();
            foreach (var item in temp)
            {
                var user = mapper.Map<GetUserVM>(item);
                result.Add(user);  
            }
            return result ; 
        }

        public GetUserVM GetUserVM(string id)
        {
            var user  = userRepo.GetById(id);
            var result = mapper.Map<GetUserVM>(user);
            return result ; 
        }

        public async Task<bool> SignInUserAsync(LoginVM model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                if (result.IsLockedOut)
                {
                    Console.WriteLine("User is locked out.");
                }
                else if (result.RequiresTwoFactor)
                {
                    Console.WriteLine("Two-factor authentication required.");
                }
                else if (result.IsNotAllowed)
                {
                    Console.WriteLine("Login not allowed. Likely due to unconfirmed email.");
                }
                else
                {
                    Console.WriteLine("Login failed. Incorrect email or password.");
                }
            }

            return false;
        }


        public void SignoutUser()
        {
            signInManager.SignOutAsync();
        }

        public bool UpdateRole(UpdateRoleVM model,Roles role)
        {
            var user = userRepo.GetById(model.UserId);
            
            return userRepo.UpdateRole(user, role);
        }

        public bool UpdateUser(EditUserVM model)
        {
            var user = mapper.Map<User>(model);
            return userRepo.UpdateUser(user);
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient("smtp.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("rg_storeproject@outlook.com", "123456789/."),
                    EnableSsl = true,
                })
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("rg_storeproject@outlook.com"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(to);

                    // Use SendMailAsync if available or wrap the synchronous call in a Task
                    await Task.Run(() => smtpClient.Send(mailMessage));
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Exception occurred in SendEmail: {ex.Message}");
                // Consider rethrowing or handling it based on your application needs
            }
        }

        public async Task<bool> ConfirmEmailAsync(string token)
        {
            var user = await userRepo.GetUserByTokenAsync(token);
            if (user != null)
            {
                await userRepo.ConfirmEmailAsync(user);
                await signInManager.SignInAsync(user, isPersistent: true);
                return true;
            }
            return false;
        }
        public async Task GenerateEmailConfirmationTokenAsync(string id, string token)
        {
            await userRepo.UpdateEmailConfirmationTokenAsync(id, token);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await userRepo.GetByEmailAsync(email);
        }

    }
}