using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Repo.Abstraction
{
    public interface IItemRepo
    {
        public Task<bool> Create(Item item);
        public Task<bool> Update(Item item);
        public Task<bool> Delete(Item item);
        public Task<IEnumerable<Item>> GetAll();
        public Task<Item> GetById(int id);
    }
}
