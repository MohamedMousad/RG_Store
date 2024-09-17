using Microsoft.AspNetCore.Mvc;

namespace RG_Store.PLL.Controllers
{
    public class Customer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Profile(string email)
        {
            /*var user = */
            return View();
        }
    }
}
