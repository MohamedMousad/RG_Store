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
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public bool AddToCart(Item item, string Uid)
        {
            try
            {
                var cart = context.Carts
                       .Include(c => c.Items)
                       .FirstOrDefault(c => c.UsertId == Uid);
                if (cart != null)
                {
                    var CartItems = cart.Items.ToList();
                    CartItems.Add(item);
                    context.SaveChanges();  
                    return true;
                }       
                return false; 
            }
            catch (Exception)
            {
                return false; 
            }            
        }
        public bool ClearCart(string UId)
        {
            try
            {
                var cart = context.Carts
               .Include(c => c.Items)
                .FirstOrDefault(c => c.UsertId == UId);
                var cartItems = cart.Items.ToList();
                foreach(var it in cartItems)
                {
                    RemoveFromCart(it, UId);
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           

        }

        public IEnumerable<Item> GetAllItems(string Uid)
        {
            try
            {
                var cart = context.Carts
                    .Include(c => c.Items)
                     .FirstOrDefault(c => c.UsertId == Uid);
                var cartItems = cart.Items.ToList();
                return cartItems;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Item>();
            }           
        }

        public Cart GetById(int id)
        {
            return context.Carts.Where(c => c.Id == id).FirstOrDefault();

        }

        public bool RemoveFromCart(Item item, string UId)
        {
            try
            {
                var cart = context.Carts
                .Include(c => c.Items)
                       .FirstOrDefault(c => c.UsertId == UId);
                if (cart!=null&&cart.Items != null)
                {
                    var CartItems = cart.Items.ToList();
                    CartItems.Remove(item);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
