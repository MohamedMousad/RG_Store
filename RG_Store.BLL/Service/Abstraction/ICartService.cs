using Entities;
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
        public Task<bool> AddToCart(int itemid, int cartId);
        public Task<bool> RemoveFromCart(int ItemId, int id);
        public  Task<IEnumerable<GetAllItemVM>> GetAllItems(int id);
        public Task<bool> ClearCart(int id);
    }
}
