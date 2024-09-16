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


        /*User GetByEmail(string email);*/
        public  Task UpdateEmailConfirmationTokenAsync(string id, string token);
        public Task<User> GetUserByTokenAsync(string token);
        public Task ConfirmEmailAsync(User user);
        public Task<User> GetByEmailAsync(string email);
      


    }
}
