using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pro.ViewModel;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;

namespace RG_Store.PLL.Controllers
{
    public class OrderController:Controller
    {
        IOrderService orderService;
        private readonly UserManager<User> userManager;

        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> GetAllOrders()// for admin
        {
            return View();
        }
        public async Task<IActionResult> Index(string userid) 
        {
       /*     var user = await userManager.GetUserAsync(User);*/
            var orders = await orderService.GetAllUserOrders(userid);

            return View(orders);
        }
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

                bool result = await orderService.CreateOrder(cartId ?? 3005,user.Id);
                Console.WriteLine(result);
                if (result)
                {
                    TempData["SuccessMessage"] = "Item added to cart successfully!";
                    return RedirectToAction("Index", "Home");
                    
                    return RedirectToAction("Index", "Cart", new { id = cartId });
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to add item to cart!";
                }

                return RedirectToAction("Index", "Home");
                return RedirectToAction("Index", "Cart", new { id = cartId });
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while processing your request.";
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Update()
        { 
            return View();
        }
        public async Task<IActionResult> Delete()
        { 
            return View();
        }

    }
}
