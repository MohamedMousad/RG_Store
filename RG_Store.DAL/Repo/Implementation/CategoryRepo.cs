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
        private readonly ApplicationDbContext context = new ApplicationDbContext();
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
                var cat = context.Categories.Where(c => c.Id == category.Id).FirstOrDefault();
                cat.IsDeleted = !cat.IsDeleted;
                context.SaveChanges();                
                return true;
            }
            catch (Exception)
            {
                return false;   
            }
        }
        
        public IEnumerable<Category> GetAllItems(Category category)=>context.Categories.Where(c=>c.Id== category.Id).ToList();
        public IEnumerable<Category> GetAll() => context.Categories.ToList();

        public Category GetById(int id)
        {
            return context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Update(Category category)
        {
            try
            {
                var cat = context.Categories.Where(c => c.Id == category.Id).FirstOrDefault();
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
    }
}
