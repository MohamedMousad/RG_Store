using RG_Store.BLL.ModelVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RG_Store.BLL.ModelVM.ChangePassVM;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.ModelVM.VerifyEmailVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;
using RG_Store.Services.Implementation;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RG_Store.PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(RegisterVM model)
        {
            if (ModelState.IsValid)
            {

                if (userService.CreateUser(model, out string[] errors))
                {
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

        [HttpPost]
        public IActionResult SignIn(LoginVM model)
        {
            if (userService.SignInUser(model))
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        public Task<IActionResult> Logout()
        {
            userService.SignoutUser();
            return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
        }
        [HttpGet]
        public IActionResult RequestConfirmationCode()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestConfirmationCode(RequestConfirmationCodeVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var code = GenerateConfirmationCode();
                    var result = await userService.SendConfirmationEmailAsync(user.Email, code);
                    if (result)
                    {
                        return RedirectToAction("VerifyEmail", new { email = model.Email });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to send confirmation code.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No user found with this email.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult VerifyEmail(string email)
        {
            return View(new VerifyEmailVM { Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await userService.ConfirmEmailAsync(user, model.ConfirmationCode);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email verification failed.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No user found with this email.");
                }
            }
            return View(model);
        }

        private string GenerateConfirmationCode()
        {
            // Generate a random confirmation code
            return Guid.NewGuid().ToString("N").Substring(0, 6);
        }

        [HttpGet]
        public IActionResult ChangePassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }
            return View(new ChangePasswordVM { Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(model.NewPassword))
                    {
                        var result = await userService.AddPasswordAsync(user, model.NewPassword);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("SignIn", "Account");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "New password cannot be empty.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found!");
                }
            }
            return View(model);
        }
    }
}