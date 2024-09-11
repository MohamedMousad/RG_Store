using Entities;
using RG_Store.DAL.DB;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Repo.Implementation
{
    public class FavouriteRepo : IFavouriteRepo
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public bool Add(Item item,int id)
        {
            try
            {
                var fav = context.Favourites.Where(f => f.Id == id).FirstOrDefault();
                var items = fav.Items.ToList();
                items.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Item> GetAll(int id)
        {
             var list = context.Favourites.Where(f => f.Id == id).FirstOrDefault().Items.ToList();
             return list;
        }

        public Favourite GetById(int id)
        {
            throw new NotImplementedException();
        }
        public bool Remove(Item item,int ID)
        {
            try
            {
                var fav = context.Favourites.Where(f=>f.Id==ID).FirstOrDefault();
                var items = fav.Items.ToList();
                var ToRemove = items.Where(f => f.Id == item.Id).FirstOrDefault();
                items.Remove(ToRemove);
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
