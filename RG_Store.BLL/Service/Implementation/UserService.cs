using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Identity;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Implementation
{
    public class UserService:IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public bool SignUp(RegisterVM registerVM)
        {
            User Result = mapper.Map<User>(registerVM);
                userManager.CreateAsync(Result);
            return true; 
        }
    }
}
