using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;
using System.Threading.Tasks;

namespace RG_Store.PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IEmailService emailService;

        public AccountController(IUserService userService, IEmailService emailService)
        {
            this.userService = userService;
            this.emailService = emailService;
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

                    
                    var user = userService.GetByEmail(model.Email); 
                    string token = Guid.NewGuid().ToString(); 

                    
                    userService.GenerateEmailConfirmationToken(user.Id, token);

                   
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { token = token }, protocol: Request.Scheme);

                    
                    emailService.SendEmail(user.Email, "Confirm your email",
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
        public ActionResult ConfirmEmail(string token)
        {
            bool isConfirmed = userService.ConfirmEmail(token);
            if (isConfirmed)
            {
                ViewBag.Message = "Your email has been confirmed successfully!";
                return View();
            }

            ViewBag.Message = "Invalid or expired token!";
            return View();
        }


    }
}
