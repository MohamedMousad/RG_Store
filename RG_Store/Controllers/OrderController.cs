using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pro.ViewModel;
using RG_Store.BLL.Service.Abstraction;

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

            return View();
        }
        public async Task<IActionResult> Create()
        {
             var user = await userManager.GetUserAsync(User);
             var res =   await  orderService.CreateOrder(user.CartId??3, user.Id);
            Console.WriteLine(res);
            return View();
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
