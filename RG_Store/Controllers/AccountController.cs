﻿using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using System.Threading.Tasks;

namespace RG_Store.PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly SignInManager<User> signInManager;

        public AccountController(IUserService userService, SignInManager<User> signInManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
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

                if (userService.CreateUser(model, out string[] errors))
                {

                  var user = userService.GetByEmail(model.Email);
                    string token = Guid.NewGuid().ToString();


                    userService.GenerateEmailConfirmationToken(user.Id, token);


                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { token = token }, protocol: Request.Scheme);


                    userService.SendEmail(user.Email, "Confirm your email",
                        $"Please confirm your email by clicking this <a href='{confirmationLink}'>link</a>.");


                   ViewBag.Message = "Registration successful! Please check your email to confirm your account.";

                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        public async Task<IActionResult> SignIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // التأكد من صحة بيانات تسجيل الدخول باستخدام signInManager
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
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
            bool isConfirmed = userService.ConfirmEmail(token);
            if (isConfirmed)
            {
                ViewBag.Message = "Your email has been confirmed successfully!";

                return View(model: token); // Pass token as a string to the view
            }

            ViewBag.Message = "Invalid or expired token!";
            return View(model: token);
        }


    }
}
