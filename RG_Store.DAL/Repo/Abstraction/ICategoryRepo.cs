using RG_Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Repo.Abstraction
{
    public interface ICategoryRepo
    {
        public bool Create(Category category);
        public bool Update(Category category);  
        public bool Delete(Category category);  
        public IEnumerable<Category> GetAllItems(Category category);
        public IEnumerable<Category> GetAll();
     //   public Category GetById(int id);
    }
}
