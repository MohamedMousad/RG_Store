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

        public async Task<bool> Create(User user)
        {
            try
            {

                Favourite favourite = new Favourite();
                context.Favourites.Add(favourite);
                await context.SaveChangesAsync();
                user.Favourite = favourite;

                Cart cart = new Cart();
                await context.Carts.AddAsync(cart);

                await context.SaveChangesAsync();
                user.Cart = cart;

                await context.Users.AddAsync(user);

                await context.SaveChangesAsync();

                cart.UserId = user.Id;
                cart.User = user;

            await    context.SaveChangesAsync();

                //favourite.UserId =user.Id;
                favourite.User = user;

              await  context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(User user)
        {
            try
            {
                var usr = await context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                usr.IsDeleted = !usr.IsDeleted;
               await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }

        public async Task<User> GetById(string id) =>await context.Users.Where(u => u.Id == id).Include(u=>u.Orders).FirstOrDefaultAsync();

        public async Task<bool> UpdateRole(User user, Roles role)
        {
            try
            {
                var usr = await GetById(user.Id);
               usr.UserRole = role;
             await   context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                var usr = await GetById(user.Id);
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.UserGender = user.UserGender;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

     public  async Task<IEnumerable<User> >GetAll() =>await context.Users.ToListAsync();


        public async Task<User> GetByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }


        public async Task UpdateEmailConfirmationTokenAsync(string id, string token)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null)
            {
                user.EmailConfirmationToken = token;
                await context.SaveChangesAsync();
            }
        }

        public async Task ConfirmEmailAsync(User user)
        {
            user.EmailConfirmed = true;
            await context.SaveChangesAsync();
        }

        public async Task<User> GetUserByTokenAsync(string token)
        {
           
                return await context.Users.FirstOrDefaultAsync(u => u.EmailConfirmationToken == token);
           
        }

    }
}