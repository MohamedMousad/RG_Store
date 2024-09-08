using Entities;
using Microsoft.AspNetCore.Mvc;
using Pro.ViewModel;

namespace RG_Store.PLL.Controllers
{
    public class OrderController
    {
        /*CreateOrder CreateOrder = new CreateOrder();
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

            return View("UV", createOrderViewModels);
        }*/
    }
}
