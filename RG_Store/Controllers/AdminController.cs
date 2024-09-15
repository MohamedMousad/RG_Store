using Entities;
using Microsoft.AspNetCore.Mvc;

namespace RG_Store.PLL.Controllers
{
    public class AdminController : Controller
    {
        /*        public IActionResult adminLogin(Admin login)
                {
                   *//* var admin = db.Admins.Where(X => X.adminemail == login.adminemail && X.adminpassword == login.adminpassword).Count();
                    if (!ModelState.IsValid)
                    {
                        return View(login);
                    }
                    else if (admin > 0)
                    {
                        return View("AV");
                    }
                    else
                    {
                        return View(login);
                    }
                }*//*
            }*/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
    }
}
