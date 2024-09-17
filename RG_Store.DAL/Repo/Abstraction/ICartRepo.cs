using Entities;
using RG_Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Repo.Abstraction
{
    public interface ICartRepo
    {
        public Task<bool> AddToCart(Item item, int cartId);
        public Task<bool> RemoveFromCart(int itemid, int Id);
        public Task<bool> ClearCart(int Id);
        public  Task<IEnumerable<Item>> GetAllItems(int id);
        public Task<Cart> GetById(int id);

    }
}
