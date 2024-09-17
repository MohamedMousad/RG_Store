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
            Task<bool> SignInUserAsync(LoginVM model);
            public void SignoutUser();
         public bool UpdateRole(UpdateRoleVM model, Roles role);

         public bool UpdateUser(EditUserVM model);
         public bool DeleteUser(DeleteUserVM model);

         public GetUserVM GetUserVM(string id);

         public IEnumerable<GetUserVM> GetAll();



            public  Task SendEmailAsync(string to, string subject, string body);


            public  Task<bool> ConfirmEmailAsync(string token);
            public  Task GenerateEmailConfirmationTokenAsync(string id, string token);
            public  Task<User> GetByEmailAsync(string email);
            Task<string> GeneratePasswordResetTokenAsync(string email);
            Task<bool> ResetPasswordAsync(string email, string token, string newPassword);

        }
    }

}
