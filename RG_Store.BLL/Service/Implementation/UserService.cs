using AutoMapper;
using Entities;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.Services.Implementation;
/*using RG_Store.BLL.ModelVM.UserVM;*/
using Microsoft.AspNetCore.Identity;

namespace RG_Store.BLL.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly CustomUserManager userManager;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;
        public UserService(CustomUserManager userManager, IMapper mapper,SignInManager<User> signInManager)
        {
            this.signInManager=signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public bool CreateUser(RegisterVM registerVM, out string[] errors)
        {
            User user = mapper.Map<User>(registerVM);

            var result = userManager.CreateAsync(user, registerVM.Password).GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                errors = null; 
                return true;
            }
            else
            {
                errors = result.Errors.Select(e => e.Description).ToArray();
                return false;
            }
        }

        public bool SignInUser(LoginVM model)
        {

            var result = signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SignoutUser()
        {
            signInManager.SignOutAsync();
        }
    }
}