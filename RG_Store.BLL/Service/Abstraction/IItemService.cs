using RG_Store.BLL.ModelVM.ItemVM;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface IItemService
    {
        public Task<bool> Create(CreateItemVM createItemVM);
        public Task<bool> Update(UpdateItemVM updateItem);
        public Task<bool> Delete(DeleteItemVM deleteItem);
        public Task<GetAllItemVM> GetAllItem(int id);
        public Task<IEnumerable<GetAllItemVM>> GetAll();
    }
}
