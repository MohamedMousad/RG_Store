/*using EmployeeSystem.DAL.Entities*/
using Entities;
using RG_Store.DAL.Enums;

namespace EmployeeSystem.DAL.Repo.Abstraction
{
    public interface IUserRepo
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<bool> Create(User user);
        public Task<bool> UpdateRole(User user, Roles role);
        public Task<bool> UpdateUser(User user);
        public Task<bool> DeleteUser(User user);
        public Task<User> GetById(string id);


        /*User GetByEmail(string email);*/
        public Task UpdateEmailConfirmationTokenAsync(string id, string token);
        public Task<User> GetUserByTokenAsync(string token);
        public Task ConfirmEmailAsync(User user);
        public Task<User> GetByEmailAsync(string email);



    }
}
