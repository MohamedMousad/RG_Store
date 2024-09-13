using Microsoft.AspNetCore.Mvc;

namespace RG_Store.PLL.Controllers
{
    public class AccountController:Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
