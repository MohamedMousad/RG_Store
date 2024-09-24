using RG_Store.BLL.ModelVM.Category;
using RG_Store.BLL.ModelVM.ItemVM;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface ICategoryService
    {
        public Task<bool> Create(AddCategoryVM CategoryVM);
        public Task<GetCategoryVM> Get(int id);
        public Task<bool> Update(UpdateCategoryVM CategoryVM);
        public Task<bool> Delete(DeleteCategoryVM CategoryVM);
        public Task< IEnumerable<GetCategoryVM>> GetAll();
        public Task<bool> AddToCategory(int itemid, int id);
        public Task<bool> RemoveCategory(int itemid,int id);
        public Task<IEnumerable<GetAllItemVM>> GetAllItems(int id);
    }
}
