using EmployeeSystem.DAL.DB;
using EmployeeSystem.DAL.Entities;
using EmployeeSystem.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Repo.Implementation
{
    public class ItemRepo : IItemRepo
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public bool Create(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Edit(Department department)
        {
            var dept = _context.Employees.Where(e => e.Id == department.Id).FirstOrDefault();
            try
            {
                dept.Name = department.Name;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public IQueryable<Department> GetAll() => _context.Departments;
        public Department GetById(int id) => _context.Departments.Where(e => e.Id == id).FirstOrDefault();
    }
}
