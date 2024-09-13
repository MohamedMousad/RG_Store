using RG_Store.BLL.ModelVM.ItemVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface ICartService
    {
        public bool AddToCart(int ItemId, int id);
        public bool RemoveFromCart(int ItemId, int id);
        public IEnumerable<GetAllItemVM> GetAll(int id);
        public bool ClearCart(int id);
        public decimal? GetCartPrice(int id);
    }
}
