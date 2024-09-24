using Entities;
using RG_Store.DAL.Entities;

namespace RG_Store.DAL.Repo.Abstraction
{
    public interface ICategoryRepo
    {
        public Task<bool> Create(Category category);
        public Task<bool> AddToCategory(Item category, int id);
        public Task<bool> RemoveFromCategory(Item category, int id);
        public Task<bool> Update(Category category);
        public Task<bool> Delete(int id);
        public Task<IEnumerable<Item>>GetAllItems(int id);
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> GetById(int id);
    }
}
