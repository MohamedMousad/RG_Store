using Entities;
using Microsoft.AspNetCore.Mvc;
using Pro.ViewModel;

namespace RG_Store.PLL.Controllers
{
    public class OrderController:Controller
    {
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
