using Entities;
using Microsoft.AspNetCore.Identity;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Abstraction
{
    namespace RG_Store.BLL.Service.Abstraction
    {
        public interface IUserService
        {
         public bool CreateUser(RegisterVM registerVM, out string[] errors);
         public bool SignInUser(LoginVM model);
         public void SignoutUser();
         public bool UpdateRole(UpdateRoleVM model, Roles role);

         public bool UpdateUser(EditUserVM model);
         public bool DeleteUser(DeleteUserVM model);

         public GetUserVM GetUserVM(string id);

         public IEnumerable<GetUserVM> GetAll();


        }
    }

}
