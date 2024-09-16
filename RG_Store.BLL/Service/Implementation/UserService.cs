using AutoMapper;
using Entities;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using RG_Store.Services.Implementation;
using Microsoft.AspNetCore.Identity;
using EmployeeSystem.DAL.Repo.Abstraction;
using RG_Store.DAL.Enums;
using RG_Store.BLL.Service.Abstraction;

namespace RG_Store.BLL.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly CustomUserManager userManager;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;
        private readonly IUserRepo userRepo;
        private readonly IEmailService _emailService;
        public UserService(CustomUserManager userManager, IMapper mapper,SignInManager<User> signInManager, IUserRepo userRepo, IEmailService emailService)
        {
            this.signInManager=signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.userRepo = userRepo;  
            _emailService = emailService;
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

        public bool DeleteUser(DeleteUserVM model)
        {
            var user = mapper.Map<User>(model);
            return userRepo.DeleteUser(user);
        }

        public IEnumerable<GetUserVM> GetAll()
        {
           List<GetUserVM> result = new List<GetUserVM>();
            var temp = userRepo.GetAll().ToList();
            foreach (var item in temp)
            {
                var user = mapper.Map<GetUserVM>(item);
                result.Add(user);  
            }
            return result ; 
        }

        public GetUserVM GetUserVM(string id)
        {
            var user  = userRepo.GetById(id);
            var result = mapper.Map<GetUserVM>(user);
            return result ; 
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

        public bool UpdateRole(UpdateRoleVM model,Roles role)
        {
            var user = userRepo.GetById(model.UserId);
            
            return userRepo.UpdateRole(user, role);
        }

        public bool UpdateUser(EditUserVM model)
        {
            var user = mapper.Map<User>(model);
            return userRepo.UpdateUser(user);
        }
        public bool ConfirmEmail(string token)
        {
            var user = userRepo.GetUserByToken(token);
            if (user != null)
            {
                userRepo.ConfirmEmail(user);
                return true;
            }
            return false;
        }
        public void GenerateEmailConfirmationToken(string id, string token)
        {
           
            userRepo.UpdateEmailConfirmationToken(id, token);
        }
        public User GetByEmail(string email)
        {
            return userRepo.GetByEmail(email);  
        }

    }
}