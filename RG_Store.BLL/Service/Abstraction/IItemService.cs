using Entities;
using RG_Store.BLL.ModelVM.ItemVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface IItemService
    {
        public bool Create(CreateItemVM createItemVM);
        public bool Update(UpdateItemVM updateItem);
        public bool Delete(DeleteItemVM deleteItem);
        public bool GetAllItem(GetAllItemVM deleteItem);
        T GetById<T>(int id, Func<Item, T> converter);
        public IEnumerable<GetAllItemVM> GetAll();
    }
}
