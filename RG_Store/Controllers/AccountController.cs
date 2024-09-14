using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction;

namespace RG_Store.PLL.Controllers
{
    public class AccountController:Controller
    {
        IUserRepo userRepo;

        public AccountController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            User temp = new User
            {
                FirstName = "Mohamed",
                LastName = "Elbhairy",
                Email = "s@gmail.com",
                UserGender = DAL.Enums.Gender.Male,
                UserName = "Mohamed",
                PasswordHash = "12345"
            };
            userRepo.Create(temp);
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult Profile(string id)
        {
            var Res = userRepo.GetById(id);
            return View(Res);
        }
    }
}
