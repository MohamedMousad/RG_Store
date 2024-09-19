using Entities;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.ModelVM.OrderVM;

namespace RG_Store.BLL.Service.Abstraction
{
    public interface IOrderService
    {
        public Task<bool> CreateOrder(int cartid, string userid);
        public Task<bool> UpdateOrder(Order orderid);
        public Task<bool> DeleteOrder(int orderid);
        public Task<IEnumerable<GetOrderVM>> GetAllOrders();
        public Task<IEnumerable<GetOrderVM>> GetAllUserOrders(string userid);
        public Task<IEnumerable<GetAllItemVM>> GetAllOrderItem(int id);
        public Task<Order> GetById(int id);

    }
}
