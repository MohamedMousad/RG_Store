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
        public bool AddToCart(Item item,string UId);
        public bool RemoveFromCart(Item item, string UId);  
        public bool ClearCart(string UId);  
        public IEnumerable<Item> GetAllItems(string Uid);
        public Cart GetById(int id);

    }
}
