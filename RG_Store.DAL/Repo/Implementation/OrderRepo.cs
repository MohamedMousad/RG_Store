/*using EmployeeSystem.DAL.DB;
using EmployeeSystem.DAL.Entities;*/
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Enums;
using RG_Store.DAL.Repo.Abstraction;

namespace EmployeeSystem.DAL.Repo.Implementation
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext context;
        private readonly ICartRepo cartRepo;
        private readonly IItemRepo itemRepo;
        private readonly IUserRepo userRepo;

        public OrderRepo(ApplicationDbContext context, IItemRepo itemRepo, ICartRepo cartRepo, IUserRepo userRepo)
        {
            this.context = context;
            this.itemRepo = itemRepo;
            this.cartRepo = cartRepo;
            this.userRepo = userRepo;

        }

        public async Task<bool> CreateOrder(int cartid, string userid)
        {

            try
            {
                var items = await cartRepo.GetAllItems(cartid);

                var user = await userRepo.GetById(userid);

                Order order = new Order();

                order.UserId = userid;

                await context.Orders.AddAsync(order);

                await context.SaveChangesAsync();

                foreach (var Item in items)
                {
                    OrderItem orderItem = new OrderItem();

                    orderItem.Order = order;
                    orderItem.OrderId = order.Id;
                    orderItem.Item = Item;
                    orderItem.ItemId = Item.Id;

                    order.TotalCost += (decimal)Item.FinalPrice;

                    await context.OrderItems.AddAsync(orderItem);

                }
                await cartRepo.ClearCart(cartid);
                await context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;

            }
        }

        public async Task<bool> DeleteOrder(int orderid)
        {
            try
            {
                var order = await GetById(orderid);

                order.OrderStatus = OrderStatus.Canceled;

                await context.SaveChangesAsync();


                return true;


            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<IEnumerable<Item>> GetAllOrderItem(int id)
        {
            return await context.OrderItems.Select(i => i.Item).Where(order => order.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {

            try
            {
                var List = await context.Orders.ToListAsync();
                return List;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Order>();
            }
        }

        public async Task<IEnumerable<Order>> GetAllUserOrders(string userid)
        {
            try
            {

                var List = await GetAllOrders();
                var ret = new List<Order>();
                foreach (var i in List)
                {
                    ret.Add(i);
                }

                return ret;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Order>();
            }
        }

        public async Task<Order> GetById(int id)
        {
            return await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> UpdateOrder(Order ordervm)
        {
            try
            {
                var order = await GetById(ordervm.Id);

                order.OrderStatus = ordervm.OrderStatus;

                if (order.OrderStatus == OrderStatus.Completed)
                {
                    var items = await context.OrderItems.Include(i => i.Item).Where(i => i.OrderId == order.Id).ToListAsync();
                    for (int i = 0; i < items.Count; i++)
                    {
                        items[i].Item.Quantity--;
                        items[i].Item.Quantity = Math.Max(items[i].Item.Quantity, 0);
                    }
                }

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}