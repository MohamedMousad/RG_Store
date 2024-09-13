using RG_Store.BLL.ModelVM.OrderVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface IOrderService
    {
        public bool Create(CreateOrderVM orderVM);
        public GetOrderVM Get(int id);
        public bool Update(UpdateOrderVM orderVM);
        public bool Cancle(CancelOrderVM orderVM);
        public IEnumerable<GetOrderVM> GetAll();

    }
}
