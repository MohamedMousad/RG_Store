using EmployeeSystem.BLL.ModelVM.EmployeeVM;
using EmployeeSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.BLL.Service.Abstraction
{
    public interface IEmployeeService
    {
        List<GetAllEmployeeVM> GetAll();
        public bool Create(CreateEmployeeVM employeeVM );
    }
}