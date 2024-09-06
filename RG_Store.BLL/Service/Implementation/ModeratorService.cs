using EmployeeSystem.BLL.ModelVM.EmployeeVM;
using EmployeeSystem.BLL.Service.Abstraction;
using EmployeeSystem.DAL.Entities;
using EmployeeSystem.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.BLL.Service.Implementation
{
    public class ModeratorService : IAdminService
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IOrderService departmentService; // Add this line

        public ModeratorService(IEmployeeRepo employeeRepo, IOrderService departmentService) // Modify constructor
        {
            this.employeeRepo = employeeRepo;
            this.departmentService = departmentService; // Initialize departmentService
        }

        public List<GetAllEmployeeVM> GetAll()
        {
            var Result = employeeRepo.GetAll().ToList();
            List<GetAllEmployeeVM> newResult = new List<GetAllEmployeeVM>();
            foreach (var item in Result)
            {
                GetAllEmployeeVM modelvm = new GetAllEmployeeVM()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    CreatedOn = item.CreatedOn,
                    isDeleted = item.isDeleted,
                    DepartmentName = item.Department != null ? item.Department.Name : null
                };
                newResult.Add(modelvm);
            }
            return newResult;
        }

        public bool Create(CreateEmployeeVM employeeVM)
        {
            var departments = departmentService.GetAll();
            var departmentId = departments.Where(x => x.Name == employeeVM.DepartmentName).FirstOrDefault();

            if (departmentId == null)
            {
                // Log the department names and the provided DepartmentName
                Console.WriteLine("Available Departments: " + string.Join(", ", departments.Select(d => d.Name)));
                Console.WriteLine("Provided DepartmentName: " + employeeVM.DepartmentName);
                throw new Exception("Department not found");
            }

            Employee employee = new Employee()
            {
                Name = employeeVM.Name,
                Age = employeeVM.Age,
                Salary = employeeVM.Salary,
                Email = employeeVM.Email,
                DepartmentId = departmentId.Id // Assign departmentId
            };
            return employeeRepo.Create(employee);
        }
    }
}
