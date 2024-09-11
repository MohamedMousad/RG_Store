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
    public class OrderRepo : IOrderRepo 
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        public bool CreateOrder(Order order)
        {
            try
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        public bool DeleteOrder(Order order)
        {
            try
            {
                var ord = context.Orders.Where(o => o.Id == order.Id).FirstOrDefault();
                ord.OrderStatus = OrderStatus.Canceled;
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false; 
            }
        }

        public IEnumerable<Order> GetAll()=>context.Orders.ToList();
       

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order order)
        {
            try
            {
                var ord = context.Orders.Where(o => o.Id == order.Id).FirstOrDefault();
                ord.OrderStatus = order.OrderStatus;
                ord.TotalCost =order.TotalCost;
                ord.Items=order.Items;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
