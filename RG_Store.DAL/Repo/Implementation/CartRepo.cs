using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Repo.Implementation
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext context ;

        User x = new();
        
        public CartRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool AddToCart(Item item, int Id)
        {
            try
            {
              
                var CartItems =GetAllItems(Id).ToList();
                CartItems.Add(item);
                context.SaveChangesAsync();
                return true; 
            }
            catch (Exception)
            {
                return false; 
            }            
        }
        public bool ClearCart(int Id)
        {
            try
            {

                var cartItems = GetAllItems(Id).ToList();
                foreach(var it in cartItems)
                {
                    RemoveFromCart(it,Id);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           

        }

        public IEnumerable<Item> GetAllItems(int id)
        {
            try
            {
                var cart = GetById(id);
                var item = cart.Items .ToList();
                return item;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Item>().ToList();
            }           
        }

        public Cart GetById(int id)=>context.Carts.Include(c=>c.Items).Where(c => c.Id == id).FirstOrDefault();
        public bool RemoveFromCart(Item item, int Id)
        {
            try
            {
                var CartItems = GetAllItems(Id).ToList();
                var ToRemove = CartItems.FirstOrDefault(i => i.Id == item.Id);
                CartItems.Remove(ToRemove);
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
