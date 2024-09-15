/*using EmployeeSystem.DAL.DB;
using EmployeeSystem.DAL.Entities;*/
using EmployeeSystem.DAL.Repo.Abstraction;
using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EmployeeSystem.DAL.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private ApplicationDbContext context;

        public UserRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(User user)
        {
            try
            {

                Favourite favourite = new Favourite();
                context.Favourites.Add(favourite);
                context.SaveChanges();
                user.Favourite = favourite;

                Cart cart = new Cart();
                context.Carts.Add(cart);

                context.SaveChangesAsync();
                user.Cart = cart;

                context.Users.Add(user);

                context.SaveChangesAsync();

                cart.UsertId = user.Id;
                cart.User = user;

                context.SaveChangesAsync();

                //favourite.UserId =user.Id;
                favourite.User = user;

                context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                var usr = context.Users.FirstOrDefault(x => x.Id == user.Id);
                usr.IsDeleted = !usr.IsDeleted;
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }

        public User GetById(string id) => context.Users.Where(u => u.Id == id).FirstOrDefault();

        public bool UpdateRole(User user, Roles role)
        {
            try
            {
                var usr = GetById(user.Id);
                usr.UserRole = role;
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var usr = GetById(user.Id);
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                user.Email = user.Email;
                usr.UserName = user.UserName;
                usr.UserGender = user.UserGender;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        IEnumerable<User> IUserRepo.GetAll() => context.Users.ToList();
    }
}