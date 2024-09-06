using EmployeeSystem.BLL.ModelVM.DepartmentVM;
using EmployeeSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.BLL.Service.Abstraction
{
    public interface IOrderService
    {
        List<GetAllDepartmentVM> GetAll();
        public bool Create(GetAllDepartmentVM department);
    }
}
