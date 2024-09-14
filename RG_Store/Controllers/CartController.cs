using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.Service.Abstraction;

namespace RG_Store.PLL.Controllers
{
    public class CartController : Controller
    {
        ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index(int id)
        {
            var res = cartService.GetAll(id);
            return View(res);
        }
    }
}
