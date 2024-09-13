using Entities;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Implementation
{
    public class ItemService : IItemService
    {
        public bool Create(CreateItemVM createItemVM)
        {
            throw new NotImplementedException();
        }

        public bool Delete(DeleteItemVM deleteItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetAllItemVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool GetAllItem(GetAllItemVM deleteItem)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id, Func<Item, T> converter)
        {
            throw new NotImplementedException();
        }

        public bool Update(UpdateItemVM updateItem)
        {
            throw new NotImplementedException();
        }
    }
}
