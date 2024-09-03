using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pro.Models;
using Pro.ViewModel;
using System.Diagnostics;

namespace Product.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        CreateOrder CreateOrder = new CreateOrder();


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult userlogin(Userlogin log)
        {
            var user = db.UserLogins.Where(X => X.useremail == log.useremail && X.userpassword == log.userpassword).Count();
           if (!ModelState.IsValid)
            {
                return View(log);
            }
            else if (user > 0)
            {
                return View("UV");
            }
            else
            {
                return View(log);
            }
        }

        public IActionResult Login(Admin login)
        {
            var admin = db.Admins.Where(X => X.adminemail == login.adminemail && X.adminpassword == login.adminpassword).Count();
            if(!ModelState.IsValid)
            {
                return View(login);
            }
            else if (admin > 0)
            {
                return View("AV");
            }
            else
            {
                return View(login);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateOrder model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                username = model.username,
                useraddress = model.useraddress,
                usergender = model.usergender,
                userphone = model.userphone
            };
            db.Users.Add(user);
            db.SaveChanges();

            var item = new Item
            {
                itemName = model.itemName,
                itemPrice = model.itemPrice
            };
            db.Items.Add(item);
            db.SaveChanges();

            var order = new Order
            {
                orederDate = model.orederDate,
                orderCost = model.orderCost,
                orderDeliveryDate = model.orderDeliveryDate,
                userid = user.userid,
                itemid = item.itemid
            };
            db.Orders.Add(order);
            db.SaveChanges();

            return RedirectToAction("AV");
        }
        public async Task<IActionResult> AV()
        {
            if (db.Orders == null || db.Users == null || db.Items == null)
            {
                return View("Error");
            }

            var orders = await db.Orders.ToListAsync();
            var createOrderViewModels = new List<CreateOrder>();

            foreach (var order in orders)
            {
                var user = await db.Users.FindAsync(order.userid);
                var item = await db.Items.FindAsync(order.itemid);

                if (user != null && item != null)
                {
                    var createOrderViewModel = new CreateOrder
                    {
                        userid = user.userid,
                        username = user.username,
                        useraddress = user.useraddress,
                        userphone = user.userphone,
                        usergender = user.usergender,
                        orederDate = order.orederDate,
                        orderCost = order.orderCost,
                        orderDeliveryDate = order.orderDeliveryDate,
                        itemid = item.itemid,
                        itemName = item.itemName,
                        itemPrice = item.itemPrice
                    };

                    createOrderViewModels.Add(createOrderViewModel);
                }
            }

            return View(createOrderViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            var order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return RedirectToAction("AV");
        }
        public async Task<IActionResult> UV()
        {
            if (db.Orders == null || db.Users == null || db.Items == null)
            {
                return View("Error");
            }

            var orders = await db.Orders.ToListAsync();
            var createOrderViewModels = new List<CreateOrder>();

            foreach (var order in orders)
            {
                var user = await db.Users.FindAsync(order.userid);
                var item = await db.Items.FindAsync(order.itemid);

                if (user != null && item != null)
                {
                    var createOrderViewModel = new CreateOrder
                    {
                        userid = user.userid,
                        username = user.username,
                        useraddress = user.useraddress,
                        userphone = user.userphone,
                        usergender = user.usergender,
                        orederDate = order.orederDate,
                        orderCost = order.orderCost,
                        orderDeliveryDate = order.orderDeliveryDate,
                        itemid = item.itemid,
                        itemName = item.itemName,
                        itemPrice = item.itemPrice
                    };

                    createOrderViewModels.Add(createOrderViewModel);
                }
            }

            return View("UV",createOrderViewModels);
        }

    }


}



