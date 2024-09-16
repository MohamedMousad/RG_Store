using Entities;
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
            bool CreateUser(RegisterVM registerVM, out string[] errors);
            Task<User> FindByNameAsync(string? email);
            Task<User> FindByEmailAsync(string email);
            bool SignInUser(LoginVM model);
            void SignoutUser();
            Task<IdentityResult> UpdateUserAsync(EditUserVM model);
            Task<IdentityResult> RemovePasswordAsync(DeleteUserVM model);
            Task<IdentityResult> AddPasswordAsync(User user, string newPassword);
            Task<IdentityResult> ConfirmEmailAsync(User user, string confirmationCode);
            Task<bool> SendConfirmationEmailAsync(string toEmail, string confirmationCode);
        }
    }
}
