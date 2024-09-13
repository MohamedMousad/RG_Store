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
        private readonly ApplicationDbContext context;

        public FavouriteRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Add(Item item,int id)
        {
            try
            {   var items = GetAll(id).ToList();
                items.Add(item);
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
            var Fav = GetById(id);
            var items = Fav.Items.ToList();
             return items;
        }
        public Favourite GetById(int id) => context.Favourites.Where(i => i.Id == id).FirstOrDefault();
        
        public bool Remove(Item item,int ID)
        {
            try
            {
                var items = GetAll(ID).ToList();
                var ToRemove = items.Where(i => i.Id == item.Id).FirstOrDefault();
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
