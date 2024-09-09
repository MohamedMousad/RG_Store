/*using EmployeeSystem.DAL.Entities*/
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Repo.Abstraction
{
    public interface IUserRepo
    {
        public IEnumerable<User> GetAll();
        public bool Create(User user);
        public bool UpdateRole(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
        public User GetById(int id);
    }
}
