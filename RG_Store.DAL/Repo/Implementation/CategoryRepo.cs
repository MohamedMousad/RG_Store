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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext context;

        public CategoryRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(Category category)
        {
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Category category)
        {
           
            try
            {
                var cat = GetById(category.Id);
                cat.IsDeleted = !cat.IsDeleted;
                context.SaveChanges();                
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }
        
        public IEnumerable<Item> GetAllItems(int id)
        {
            var Cat = GetById(id);
            var Items = Cat.Items.ToList();
            return Items;
        }
            public IEnumerable<Category> GetAll() => context.Categories.ToList();

        public Category GetById(int id)=> context.Categories.Where(c => c.Id == id).FirstOrDefault();
   

        public bool Update(Category category)
        {
            try
            {
                var cat = GetById(category.Id);
                cat.Name = category.Name;
                cat.Description = category.Description;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddToCategory(Item item, int id)
        {
            try
            {
                var CategoryItems = GetAllItems(id).ToList();
                CategoryItems.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveFromCategory(Item item, int id)
        {

            try
            {
                var CategoryItems = GetAllItems(id).ToList();
                var itemToRemove = CategoryItems.FirstOrDefault(i => i.Id == item.Id);
                CategoryItems.Remove(itemToRemove);
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
