/*using EmployeeSystem.BLL.ModelVM.DepartmentVM;
using EmployeeSystem.BLL.ModelVM.EmployeeVM;
using EmployeeSystem.BLL.Service.Abstraction;
using EmployeeSystem.DAL.Entities;
using EmployeeSystem.DAL.Repo.Abstraction;
using EmployeeSystem.DAL.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.BLL.Service.Implementation
{
    public class AdminService : IOrderService
    {
        private readonly IDepartmentRepo departmentRepo;

        public AdminService(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        public List<GetAllDepartmentVM> GetAll()
        {
            var Result = departmentRepo.GetAll().ToList();
            List<GetAllDepartmentVM> newResult = new List<GetAllDepartmentVM>();
            foreach (var result in Result) {
                GetAllDepartmentVM modelvm = new GetAllDepartmentVM()
                {
                    Id = result.Id,
                    Name = result.Name
                };
                newResult.Add(modelvm);
            }
            return newResult;
        }

        public bool Create(GetAllDepartmentVM department)
        {
            if (departmentRepo.GetAll().Any(a => a.Name == department.Name))
            {
                return false;
            }
            return departmentRepo.Create(new Department() { Name = department.Name });
        }
    }
}
*/