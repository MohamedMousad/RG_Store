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
        public Task<bool> Add(Item itemid, int id);
        public Task<bool> Remove(int itemid, int id);
        public Task<IEnumerable<Item>> GetAll(int id);
        public Task<Favourite> GetById(int id);
    }
}
