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

        
    }
}
