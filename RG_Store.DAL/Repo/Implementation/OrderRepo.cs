/*using EmployeeSystem.DAL.DB;
using EmployeeSystem.DAL.Entities;*/
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Enums;
using RG_Store.DAL.Repo.Abstraction;
using RG_Store.DAL.Repo.Implementation;
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
        private readonly ICartRepo cartRepo;
        private readonly IItemRepo itemRepo;

        public OrderRepo(ApplicationDbContext context, IItemRepo itemRepo ,ICartRepo cartRepo)
        {
            this.context = context;
            this.itemRepo = itemRepo;
            this.cartRepo = cartRepo;

        }

        public async Task<bool> CreateOrder(Order order, int cartid)
        {
            var items = await cartRepo.GetAllItems(cartid);   
            
            foreach(var Item in items) { 
            
            }





            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllUserOrders(string userid)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        /*public OrderRepo(ApplicationDbContext context)
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
             *//*   var ord = GetById(order.Id);
                ord.OrderStatus = order.OrderStatus;
                ord.TotalCost =order.TotalCost;
                ord.Items=order.Items;
                context.SaveChanges();*//*
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }*/
    }
}