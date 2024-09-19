using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;

namespace RG_Store.PLL.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public CartController(ICartService cartService, UserManager<User> userManager, IUserService userService)
        {
            this.cartService = cartService;
            this.userManager = userManager;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var res = await cartService.GetAllItems(id);
            var ret = res.ToList();
            return View(ret);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int itemId)
        {
            try
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "User not found!";
                    return RedirectToAction("Account", "SignUp");
                }

                var cartId = user.CartId;
                if (cartId == null)
                {
                    TempData["ErrorMessage"] = "Cart ID is not available!";
                    return RedirectToAction("Index", "Home");
                }

                bool result = await cartService.AddToCart(itemId, cartId ?? 3005);

                if (result)
                {
                    TempData["SuccessMessage"] = "Item added to cart successfully!";
                    return RedirectToAction("Index", "Cart", new { id = cartId });
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to add item to cart!";
                }

                return RedirectToAction("Index", "Cart", new { id = cartId });
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while processing your request.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int itemId)
        {
            var user = await userManager.GetUserAsync(User);


            var cartId = user.CartId;

            bool result = await cartService.RemoveFromCart(itemId, cartId ?? 3005);

            if (result)
            {
                TempData["SuccessMessage"] = "Item added to cart successfully!";
                return RedirectToAction("Index", "Cart", new { id = cartId });
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add item to cart!";
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var user = await userManager.GetUserAsync(User);


            var cartId = user.CartId;

            bool result = await cartService.ClearCart(cartId ?? 3005);

            if (result)
            {
                TempData["SuccessMessage"] = "Item added to cart successfully!";
                return RedirectToAction("Index", "Cart", new { id = cartId });
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add item to cart!";
                return View();
            }

        }
    }
}
