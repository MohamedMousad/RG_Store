using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Repo.Abstraction;

namespace RG_Store.DAL.Repo.Implementation
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext context;

        public CategoryRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddToCategory(Item item, int id)
        {
            try
            {
                var ci = new CategoryItem();
                ci.CategoryId = id;
                ci.ItemId = item.Id;
                ci.Item = item;
                await context.CategoryItems.AddAsync(ci);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> Create(Category category)
        {
            try
            {
                await context.AddAsync(category);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }  
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var c = await GetById(id);
                c.IsDeleted = !c.IsDeleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItems(int id)
        {
         return await context.CategoryItems.Include(c=>c.Item).Where(Item => Item.Id == id).Select(c=>c.Item).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> RemoveFromCategory(Item item, int id)
        {
            try
            {
                var ItemToRemove =await context.Items.FirstOrDefaultAsync(i=> i.Id == item.Id);
                var ci = await context.CategoryItems.FirstOrDefaultAsync(i => i.ItemId == item.Id);
                context.Remove(ci);
                await context.SaveChangesAsync();
                        
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Category category)
        {
            try
            {
                var cat =await GetById(category.Id);
                cat.Name = category.Name;
                cat.Description = category.Description;
                context.Update(cat);
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
