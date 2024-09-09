using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Repo.Abstraction
{
    public interface ICartRepo
    {
        public bool AddToCart(Item item);
        public bool RemoveFromCart(Item item);  
        public IEnumerable<Item> GetAll();

    }
}
