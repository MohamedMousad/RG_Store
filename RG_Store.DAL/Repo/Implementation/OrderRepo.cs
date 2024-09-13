/*using EmployeeSystem.DAL.DB;
using EmployeeSystem.DAL.Entities;*/
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Repo.Implementation
{
    public class OrderRepo : IOrderRepo 
    {
        private readonly ApplicationDbContext context;

        public OrderRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CreateOrder(Order order)
        {
            try
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        public bool DeleteOrder(Order order)
        {
            try
            {
                var ord = GetById(order.Id);
                ord.OrderStatus = OrderStatus.Canceled;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false; 
            }
        }

        public IEnumerable<Order> GetAll()=>context.Orders.ToList();
       

        public Order GetById(int id)=> context.Orders.Where(c => c.Id == id).FirstOrDefault();

        public bool UpdateOrder(Order order)
        {
            try
            {
                var ord = GetById(order.Id);
                ord.OrderStatus = order.OrderStatus;
                ord.TotalCost =order.TotalCost;
                ord.Items=order.Items;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}