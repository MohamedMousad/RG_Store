/*using EmployeeSystem.DAL.Entities;*/
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Repo.Abstraction
{
    public interface IOrderRepo
    {
        public Task<bool> CreateOrder(Order order,int cartid);
        public Task<bool> UpdateOrder(Order order);
        public Task<bool> DeleteOrder(Order order);
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<IEnumerable<Order>> GetAllUserOrders(string userid);
        public Task<Order> GetById(int id);
    }
}
