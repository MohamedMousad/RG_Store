using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.ModelVM.OrderVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface IFavouriteService
    {
        public bool AddToFavorite(int ItemId, int id);
        public bool RemoveFromFavorite(int ItemId, int id);
        public IEnumerable<GetAllItemVM> GetAll(int id);
    }
}
