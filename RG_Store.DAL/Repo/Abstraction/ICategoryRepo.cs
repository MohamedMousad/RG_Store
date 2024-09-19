﻿using Entities;
using RG_Store.DAL.Entities;

namespace RG_Store.DAL.Repo.Abstraction
{
    public interface ICategoryRepo
    {
        public bool Create(Category category);
        public bool AddToCategory(Item category, int id);
        public bool RemoveFromCategory(Item category, int id);
        public bool Update(Category category);
        public bool Delete(Category category);
        public IEnumerable<Item> GetAllItems(int id);
        public IEnumerable<Category> GetAll();
        public Category GetById(int id);
    }
}
