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
        public bool CreateOrder(Order order);
        public bool UpdateOrder(Order order);
        public bool DeleteOrder(Order order);
        public IEnumerable<Order> GetAll();
       // public Order GetById(int id);
    }
}
