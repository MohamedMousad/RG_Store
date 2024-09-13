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
        public bool AddToCart(Item item,int Id);
        public bool RemoveFromCart(Item item, int  Id);  
        public bool ClearCart(int Id);  
        public IEnumerable<Item> GetAllItems(int id);
        public Cart GetById(int id);

    }
}
