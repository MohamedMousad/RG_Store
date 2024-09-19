using AutoMapper;
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.AspNetCore.Identity;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.DAL.Enums;
using RG_Store.Services.Implementation;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;

namespace RG_Store.BLL.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly CustomUserManager userManager;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;
        private readonly IUserRepo userRepo;
        public UserService(CustomUserManager userManager, IMapper mapper, SignInManager<User> signInManager, IUserRepo userRepo)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.userRepo = userRepo;
        }
        public async Task<bool> CreateUser(RegisterVM registerVM)
        {



            User user = mapper.Map<User>(registerVM);

            var result = await userManager.CreateAsync(user, registerVM.Password);
            await userManager.AddToRoleAsync(user, "Customer");
            if (result.Succeeded)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public async Task<bool> DeleteUser(DeleteUserVM model)
        {
            var user = mapper.Map<User>(model);
            return await userRepo.DeleteUser(user);
        }

        public async Task<IEnumerable<GetUserVM>> GetAll()
        {
            List<GetUserVM> resultlist = new List<GetUserVM>();
            var temp = await userRepo.GetAll();
            foreach (var user in temp)
            {
                GetUserVM result = new();
                result.UserId = user.Id;
                result.UserName = user.UserName;
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.UserGender = user.UserGender;
                result.Email = user.Email;
                result.ProfileImage = user.ProfileImage;
                result.UserRole = user.UserRole;
                resultlist.Add(result);
            }
            return resultlist;
        }

        public async Task<GetUserVM> GetUserVM(string id)
        {
            var user = await userRepo.GetById(id);
            GetUserVM result = new();
            result.UserId = user.Id;
            result.UserName = user.UserName;
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.UserGender = user.UserGender;
            result.Email = user.Email;
            result.ProfileImage = user.ProfileImage;
            result.UserRole = user.UserRole;

            return result;
        }

        public async Task<bool> SignInUserAsync(LoginVM model)
        {
            var uservm = GetByEmailAsync(model.Email);

            var result = await signInManager.PasswordSignInAsync(uservm.Result.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
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


        public async Task SignoutUser()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<bool> UpdateRole(UpdateRoleVM model, Roles rolevm)
        {
            var user = await userRepo.GetById(model.UserId);
            if (user == null)
            {
                return false;
            }
            var role = "Customer";
            if (rolevm == Roles.Admin) role = "Admin";
            /* var currentRoles = await userManager.GetRolesAsync(user);  */

            /* if (currentRoles.Contains(role))
             {*/

            var result = await userManager.RemoveFromRoleAsync(user, role);
            /*  if (!result.Succeeded)
              {

                  return false;
              }*/
            /*  }*/
            await userRepo.UpdateRole(user, rolevm);
            var addResult = await userManager.AddToRoleAsync(user, role);

            return addResult.Succeeded;
        }

        public async Task<bool> UpdateUser(GetUserVM model)
        {
            User user = new User
            {
                Id = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserGender = model.UserGender,
                ProfileImage = model.ProfileImage
            };

            return await userRepo.UpdateUser(user);
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


                    await Task.Run(() => smtpClient.Send(mailMessage));
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception occurred in SendEmail: {ex.Message}");

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
        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return null;

            var token = await userManager.GeneratePasswordResetTokenAsync(user);


            var resetLink = $"https://localhost:7126/Account/ResetPassword?token={Uri.EscapeDataString(token)}&email={email}";
            await SendEmailAsync(user.Email, "Reset your password", $@"
<html>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Email Confirmation</title>
    <style>
        body {{
            background-color: #1f1b2d;
            color: #9691a4;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }}
        .email-container {{
            width: 100%;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #0f3460;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.5);
        }}
        .header {{
            text-align: center;
            padding-bottom: 20px;
        }}
        .header img {{
            width: 100px;
        }}
        .content {{
            text-align: center;
        }}
        .content h1 {{
            color: #fd5631;
            margin-bottom: 20px;
        }}
        .content p {{
            color: #ffffff;
            font-size: 16px;
            margin-bottom: 30px;
        }}
        .confirmation-button {{
            display: inline-block;
            padding: 15px 30px;
            font-size: 16px;
            color: #ffffff;
            background-color: #fd5631;
            border-radius: 5px;
            text-decoration: none;
            margin-top: 20px;
        }}
        .confirmation-button:hover {{
            background-color: #fd390e;
        }}
        .footer {{
            text-align: center;
            padding-top: 20px;
            font-size: 12px;
            color: #a6a6a6;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>
            <img src='https://localhost:7126/images/rg_logo.png' alt='RG Store Logo'>
        </div>
        <div class='content'>
            <h1>Reset Password</h1>
            <p>Please reset your password by clicking the button below.</p>
            <a href='{resetLink}' class='confirmation-button'>Reset Password</a>
        </div>
        <div class='footer'>
            <p>If you did not request this email, please ignore it.</p>
        </div>
    </div>
</body>
</html>");

            return token;
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var result = await userManager.ResetPasswordAsync(user, token, newPassword);

            return result.Succeeded;
        }
        public async Task<User> GetUserAsync(ClaimsPrincipal principal)
        {
            return await userManager.GetUserAsync(principal);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
            {
                await signInManager.RefreshSignInAsync(user);
            }
            return result;
        }


    }
}