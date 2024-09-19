using Microsoft.AspNetCore.Mvc;
using Pro.Models;
using RG_Store.BLL.Service.Abstraction;
using System.Diagnostics;

namespace Product.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService itemService;

        public HomeController(ILogger<HomeController> logger, IItemService itemService)
        {

            this.itemService = itemService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var Result = await itemService.GetAll();
            return View(Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}



