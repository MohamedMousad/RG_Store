using Entities;
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
            Console.WriteLine("========================");

            Console.WriteLine(model.Email);
            Console.WriteLine(model.Password);
            Console.WriteLine("========================");
            if (ModelState.IsValid)
            {
                Console.WriteLine("========================");

                Console.WriteLine(model.Email);
                Console.WriteLine(model.Password);
                Console.WriteLine("========================");



                // Create user
                if (userService.CreateUser(model, out string[] errors))
                {
                    // Fetch the newly created user
                    var user =await userService.GetByEmailAsync(model.Email);

                    // Generate email confirmation token
                    string token = Guid.NewGuid().ToString();
                    userService.GenerateEmailConfirmationTokenAsync(user.Id, token);

                    // Create confirmation link
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { token = token }, protocol: Request.Scheme);

                    // Send confirmation email
                    userService.SendEmailAsync(user.Email, "Confirm your email",
                        $"Please confirm your email by clicking this <a href='{confirmationLink}'>link</a>.");

                    // Set success message
                    ViewBag.Message = "Registration successful! Please check your email to confirm your account.";

                    // Redirect to home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Add validation errors to ModelState
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
            }

            // Return the view with the model if there are validation errors
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

                return View(model: token); // Pass token as a string to the view
            }

            ViewBag.Message = "Invalid or expired token!";
            return View(model: token);
        }


    }
}
