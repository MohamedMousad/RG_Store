using Microsoft.AspNetCore.Mvc;

namespace RG_Store.PLL.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
