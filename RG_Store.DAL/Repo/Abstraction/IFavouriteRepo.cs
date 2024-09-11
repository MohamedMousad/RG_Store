using Entities;
using RG_Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Repo.Abstraction
{
    public interface IFavouriteRepo
    {
        public bool Add(Item item, int id);
        public bool Remove(Item item, int id);
        public IEnumerable<Item> GetAll(int id);
        public Favourite GetById(int id);
    }
}
