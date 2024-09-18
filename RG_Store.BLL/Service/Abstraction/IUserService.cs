using Entities;
using Microsoft.AspNetCore.Identity;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.DAL.Enums;
using System.Security.Claims;

namespace RG_Store.BLL.Service.Abstraction
{
    namespace RG_Store.BLL.Service.Abstraction
    {
        public interface IUserService
        {
            public Task<bool> CreateUser(RegisterVM registerVM/*, out string[] errors*/);
            public Task<bool> SignInUserAsync(LoginVM model);
            public Task SignoutUser();
            public Task<bool> UpdateRole(UpdateRoleVM model, Roles role);

            public Task<bool> UpdateUser(EditUserVM model);
            public Task<bool> DeleteUser(DeleteUserVM model);

            public Task<GetUserVM> GetUserVM(string id);

            public Task<IEnumerable<GetUserVM>> GetAll();

            public Task SendEmailAsync(string to, string subject, string body);
            public Task<bool> ConfirmEmailAsync(string token);
            public Task GenerateEmailConfirmationTokenAsync(string id, string token);
            public Task<User> GetByEmailAsync(string email);
            Task<string> GeneratePasswordResetTokenAsync(string email);
            Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
            Task<User> GetUserAsync(ClaimsPrincipal principal);
            Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);
  

        }
    }

}
