using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.Service.Abstraction;

namespace RG_Store.PLL.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        private readonly UserManager<User> userManager;

        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> GetAllOrders()
        {
            var res = await orderService.GetAllOrders();

            return View(orderService);
        }
        [Authorize]
        public async Task<IActionResult> Index(string userid)
        {

            var orders = await orderService.GetAllUserOrders(userid);

            return View(orders);
        }
        [Authorize]
        public async Task<IActionResult> Create()
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

                bool result = await orderService.CreateOrder(cartId ?? 3005, user.Id);
                Console.WriteLine(result);
                if (result)
                {
                    TempData["SuccessMessage"] = "Order added successfully!";

                    return RedirectToAction("Index", "Order", new { id = user.Id });
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to add item to cart!";
                }

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while processing your request.";
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public async Task<IActionResult> Update(int orderid)
        {


            return View();
        }
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            return View();
        }

    }
}
