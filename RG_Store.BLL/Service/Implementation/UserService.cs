﻿using AutoMapper;
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

            var result = userManager.CreateAsync(user, registerVM.Password).GetAwaiter().GetResult();

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
            List<GetUserVM> result = new List<GetUserVM>();
            var temp = await userRepo.GetAll();
            foreach (var item in temp)
            {
                var user = mapper.Map<GetUserVM>(item);
                result.Add(user);
            }
            return result;
        }

        public async Task<GetUserVM> GetUserVM(string id)
        {
            var user = await userRepo.GetById(id);
            var result = mapper.Map<GetUserVM>(user);
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

        public async Task<bool> UpdateRole(UpdateRoleVM model, Roles role)
        {
            var user = await userRepo.GetById(model.UserId);

            return await userRepo.UpdateRole(user, role);
        }

        public async Task<bool> UpdateUser(GetUserVM model)
        {
            User user = new User
            {
                Id = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserGender = model.Gender,
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
            await SendEmailAsync(user.Email, "Reset your password", $"Click <a href='{resetLink}'>here</a> to reset your password.");

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