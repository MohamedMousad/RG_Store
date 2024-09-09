using Entities;
using RG_Store.DAL.DB;
using RG_Store.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Repo.Implementation
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public bool AddToCart(Item item)
        {
            return 1;
        }

        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromCart(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
