
using Entities;
using RG_Store.DAL.DB;
using RG_Store.DAL.Repo.Abstraction;
using System;

namespace EmployeeSystem.DAL.Repo.Implementation
{
    public class ItemRepo : IItemRepo
    {
       private readonly ApplicationDbContext context;

        public ItemRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(Item item)
        {
            try
            {
                context.Items.Add(item);
                context.SaveChanges();
                return true;
            }
            catch { 
                return false;
            }
        }

        public bool Delete(Item item)
        {
            try
            {
                var itm = context.Items.Where(i=>i.Id == item.Id).FirstOrDefault();
                itm.IsDeleted = !itm.IsDeleted;
                context.SaveChanges();
                return true;
                
            }
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<Item> GetAll(Item item) => context.Items.ToList();

        public Item GetById(int id) => context.Items.Where(i => i.Id == id).FirstOrDefault();

        public bool Update(Item item)
        {
            try
            {
                var itm = GetById(item.Id);
                itm.Price = item.Price;
                itm.Quantity = item.Quantity;   
                itm.Name = item.Name;   
                itm.HasOffer = item.HasOffer;   
                itm.Offer = item.Offer; 
                itm.Description =item.Description;
                itm.ItemImage = item.ItemImage; 
                context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}