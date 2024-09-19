using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using System.Security.Claims;

namespace RG_Store.PLL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            //ViewBag.UserName = username;
            return View();
        }
        public IActionResult Users()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userId;
            return View();
        }

        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditUser(string userId)
        {
            if (ModelState.IsValid)
            {


                return RedirectToAction("Users");
            }
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult items()
        {
            return View();
        }

    }
}