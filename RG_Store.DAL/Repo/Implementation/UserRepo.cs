/*using EmployeeSystem.DAL.DB;
using EmployeeSystem.DAL.Entities;*/
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        
        public bool Create(User user)
        {
            throw new NotImplementedException();
        }
        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserRepo.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}