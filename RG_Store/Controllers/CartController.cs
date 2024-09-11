using Microsoft.AspNetCore.Mvc;

namespace RG_Store.PLL.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
