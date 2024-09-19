using RG_Store.BLL.ModelVM.ItemVM;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface IFavouriteService
    {
        public Task<bool> AddToFavorite(int ItemId, int id);
        public Task<bool> RemoveFromFavorite(int ItemId, int id);
        public Task<IEnumerable<GetAllItemVM>> GetAll(int id);
    }
}
