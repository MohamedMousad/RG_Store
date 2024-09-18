using Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Add(Item itemid, int id)
        {
            var fav = await GetById(id);

            try
            {
                var existingItem = await context.Items
                    .FirstOrDefaultAsync(i => i.Id == itemid.Id);
              if (existingItem == null)
                {
                      context.Attach(itemid);
                    existingItem = itemid; 
                }

                FavouriteItem ci = new FavouriteItem
                {
                    Favourite = fav,
                    FavouriteId = id,
                    Item = existingItem 
                };

                await context.FavouriteItems.AddAsync(ci);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // You can log the exception message for more insight
                return false;
            }
        }


        public async Task<IEnumerable<Item>> GetAll(int id)
        {
            try
            {
                var items = context.FavouriteItems
                  .Include(i => i.Item)
                  .Where(i => i.FavouriteId == id)
                  .Select(i => i.Item)
                  .ToList();
                return items;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Item>().ToList();
            }
        }
        public async Task<Favourite> GetById(int id)
        {
            return  context.Favourites.Where(i => i.Id == id).FirstOrDefault();
        }
        
        public async Task<bool> Remove(int itemid,int ID)
        {

            try
            {
                var itemToRemove = context.FavouriteItems
                    .FirstOrDefault(i => i.FavouriteId == ID && i.ItemId == itemid);

                if (itemToRemove != null)
                {
                    context.FavouriteItems.Remove(itemToRemove);
                    await context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
