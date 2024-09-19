using Azure.Core;
using Entities;
using Humanizer;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using RG_Store.BLL.Images;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Drawing;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using static RG_Store.BLL.ModelVM.UserVM.ForgerPasswordVM;
using static System.Net.Mime.MediaTypeNames;

namespace RG_Store.PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;



        public AccountController(IUserService userService, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                if (await userService.CreateUser(model))
                {
                    var user = await userService.GetByEmailAsync(model.Email);

                    string token = Guid.NewGuid().ToString();
                    await userService.GenerateEmailConfirmationTokenAsync(user.Id, token);

                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { token = token }, protocol: Request.Scheme);
                    string body = $@"
<html>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Email Confirmation</title>
    <style>
        body {{
            background-color: #1f1b2d;
            color: #ffffff;
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
            <h1>Email Confirmation</h1>
            <p>Please confirm your email address by clicking the button below.</p>
            <a href='{confirmationLink}' class='confirmation-button'>Confirm Email</a>
        </div>
        <div class='footer'>
            <p>If you did not request this email, please ignore it.</p>
        </div>
    </div>
</body>
</html>";

                    await userService.SendEmailAsync(user.Email, "Confirm your email",body);

                    ViewBag.Message = "Registration successful! Please check your email to confirm your account.";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    /* foreach (var error in errors)
                     {
                         ModelState.AddModelError(string.Empty, error);
                     }*/
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.SignInUserAsync(model);
                Console.WriteLine(model.Email);
                Console.WriteLine(model.Password);

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }


        public async Task<IActionResult> Logout()


        {
          await  userService.SignoutUser();
            return await Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
        }


        public async Task<IActionResult> ConfirmEmail(string token)
        {
            bool isConfirmed = await userService.ConfirmEmailAsync(token);
            if (isConfirmed)
            {
                ViewBag.Message = "Your email has been confirmed successfully!";

                return View(model: token);
            }

            ViewBag.Message = "Invalid or expired token!";
            return View(model: token);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError(string.Empty, "Please provide your email address.");
                return View();
            }

            await userService.GeneratePasswordResetTokenAsync(email);
            ViewBag.Message = "If an account with this email exists, a password reset link has been sent.";

            return View();
        }

        // Step 2: Reset Password
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ResetPasswordVM { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userService.ResetPasswordAsync(model.Email, model.Token, model.Password);
            if (result)
            {
                return RedirectToAction("SignIn");
            }

            ModelState.AddModelError(string.Empty, "Error resetting your password.");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ChangePasswordAsync()
        {
            var user = await userService.GetUserAsync(User);
            var model =new ChangePasswordVM();
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.ProfileImage = user.ProfileImage;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            /*if (!ModelState.IsValid)
            {
                return View(model);
            }*/

            var user = await userService.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var result = await userService.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Your password has been changed successfully!";
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }


            var userVM = await userService.GetUserVM(userId);

            if (userVM == null)
            {
                return NotFound("User not found");
            }

            return View(userVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GetUserVM model)
        {
            var user = await userManager.GetUserAsync(User);
            model.UserId = user.Id;
            if (model.Image != null)
            {
                var fileName = UploadImage.UploadFile("users", model.Image);
                model.ProfileImage = fileName;
            }
            var res = await userService.UpdateUser(model);
            if (res)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }


    }
}
