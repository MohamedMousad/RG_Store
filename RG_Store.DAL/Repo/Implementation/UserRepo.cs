/*using EmployeeSystem.DAL.DB;
using EmployeeSystem.DAL.Entities;*/
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Enums;
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
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                var usr = context.Users.FirstOrDefault(x => x.Id == user.Id);
                usr.IsDeleted = !usr.IsDeleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }
        public bool UpdateRole(User user,Roles role)
        {
            try
            {
                var usr = context.Users.FirstOrDefault(x => x.Id == user.Id);
                usr.IsDeleted = !usr.IsDeleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var usr = context.Users.FirstOrDefault(x => x.Id == user.Id);
                usr.FirstName =user.FirstName;
                usr.LastName =user.LastName;
                user.Email =user.Email;
                usr.UserName =user.UserName;
                usr.UserGender = user.UserGender;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        IEnumerable<User> IUserRepo.GetAll() => context.Users.ToList();
    }
}
/*  private readonly ApplicationDbContext _context = new ApplicationDbContext();
          public bool Create(Employee employee)
          {
              try
              {
                  _context.Employees.Add(employee);
                  _context.SaveChanges();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;

              }
          }

          public bool Edit(Employee employee)
          {
              var emp = _context.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
              try
              {
                  emp.Name = employee.Name;
                  emp.Age = employee.Age;
                  emp.Email = employee.Email;
                  _context.SaveChanges();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;

              }
          }

          public IQueryable<Employee> GetAll() => _context.Employees.Include(a=>a.Department).Where(a=>a.DepartmentId != null);
          public Employee GetById(int id) => _context.Employees.Where(e => e.Id == id).FirstOrDefault();*/
