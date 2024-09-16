/*using EmployeeSystem.DAL.Entities*/
using Entities;
using RG_Store.DAL.Enums;
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
        public bool UpdateRole(User user, Roles role);
        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
        public User GetById(string id);
        User GetByEmail(string email);  
        public void UpdateEmailConfirmationToken(string id, string token); 
        User GetUserByToken(string token); 
        void ConfirmEmail(User user);
        
    }
}
