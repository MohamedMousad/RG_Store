/*using EmployeeSystem.DAL.DB;
using EmployeeSystem.DAL.Entities;*/
using EmployeeSystem.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Repo.Implementation
{
    public class EmployeeRepo : IOrderRepo
    {
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

    }
}
