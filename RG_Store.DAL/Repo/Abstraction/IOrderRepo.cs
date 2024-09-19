/*using EmployeeSystem.DAL.Entities;*/
using Entities;

namespace EmployeeSystem.DAL.Repo.Abstraction
{
    public interface IOrderRepo
    {
        public Task<bool> CreateOrder(int cartid, string userid);
        public Task<bool> UpdateOrder(Order orderid);
        public Task<bool> DeleteOrder(int orderid);
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<IEnumerable<Item>> GetAllOrderItem(int id);
        public Task<IEnumerable<Order>> GetAllUserOrders(string userid);
        public Task<Order> GetById(int id);
    }
}
