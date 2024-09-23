using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.OrderVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;

namespace RG_Store.PLL.Controllers
{
    public class OrderController : Controller
    {
        IOrderService orderService;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public OrderController(IOrderService orderService, UserManager<User> userManager , IUserService userService)
        {
            this.orderService = orderService;
            this.userManager = userManager;
            this.userService = userService;
        }
        [Authorize]
        public async Task<IActionResult> GetAllOrders()
        {
            var res = await orderService.GetAllOrders();

            return View(orderService);
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user =await userManager.GetUserAsync(User);
            var orders = await orderService.GetAllUserOrders(user.Id);
            var usr = new User { Email = user.Email, UserName = user.UserName, ProfileImage = user.ProfileImage };
            ViewBag.User = usr;
            return View(orders.ToList());
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
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var it = await orderService.GetAllOrderItem(id);
            ViewBag.Items = it.ToList();

            var res = await orderService.GetById(id);

            UpdateOrderVM model = new();
            model.OrderStatus = res.OrderStatus;
            model.OrderId = res.OrderId;
            model.CreatedOn = res.CreatedOn;
            model.TotalCost = res.TotalCost;
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderVM model)
        {
            var it = await orderService.GetAllOrderItem(model.OrderId);
            ViewBag.Items = it.ToList();

            var res = await orderService.UpdateOrder(model);
            if (res) return RedirectToAction("Index", "Order");
            return View(model);
        }
    }
}
