using Entities;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;
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
        public IActionResult EditUser(int userId)
        {
            if (ModelState.IsValid)
            {
                // Add user to the database with the role
                // Redirect to the Users list or show a success message
                return RedirectToAction("Users");
            }
            return View(/*_userService.getbyid*/);
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