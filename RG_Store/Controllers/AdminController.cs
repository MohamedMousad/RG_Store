using Entities;
using Microsoft.AspNetCore.Mvc;

namespace RG_Store.PLL.Controllers
{
    public class AdminController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }
       /* public IActionResult Users()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }*/
    }
}
