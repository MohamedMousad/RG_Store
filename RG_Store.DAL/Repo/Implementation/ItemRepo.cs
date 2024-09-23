
using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Repo.Abstraction;

namespace EmployeeSystem.DAL.Repo.Implementation
{
    public class ItemRepo : IItemRepo
    {
        private readonly ApplicationDbContext context;

        public ItemRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(Item item)
        {
            try
            {
                await context.Items.AddAsync(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Item item)
        {
            try
            {
                var itm = await context.Items.Where(i => i.Id == item.Id).FirstOrDefaultAsync();
                itm.IsDeleted = !itm.IsDeleted;
                await context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Item>> GetAll() => await context.Items.ToListAsync();

        public async Task<Item> GetById(int id) => await context.Items.Where(i => i.Id == id).FirstOrDefaultAsync();

        public async Task<bool> Update(Item item)
        {
            try
            {
                
                var itm = await GetById(item.Id);
                itm.IntialPrice = item.IntialPrice;
                itm.FinalPrice = item.FinalPrice;
                itm.Quantity = item.Quantity;
                itm.Name = item.Name;
                itm.HasOffer = item.HasOffer;
                itm.Offer = item.Offer;
                itm.Description = item.Description;
                if (item.ItemImage != null)
                {
                    itm.ItemImage = item.ItemImage;
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}