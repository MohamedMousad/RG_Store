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
        public bool Create(Item item);
        public bool Update(Item item);
        public bool Delete(Item item);
        public IEnumerable<Item> GetAll(Item item);
        public Item GetById(int id);
    }
}
