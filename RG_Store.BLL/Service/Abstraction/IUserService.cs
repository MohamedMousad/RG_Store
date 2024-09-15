using Microsoft.AspNetCore.Identity;
using RG_Store.BLL.ModelVM.UserVM;
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
       
        }
    }

}
