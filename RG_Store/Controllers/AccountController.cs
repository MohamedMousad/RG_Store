using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using System.Security.Claims;
using static RG_Store.BLL.ModelVM.UserVM.ForgerPasswordVM;

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

                    await userService.SendEmailAsync(user.Email, "Confirm your email",
                        $"Please confirm your email by clicking this <a href='{confirmationLink}'>link</a>.");

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
            userService.SignoutUser();
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
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
