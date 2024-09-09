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
    public class OrderRepo : IOrderRepo 
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        public bool CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
/*
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
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
