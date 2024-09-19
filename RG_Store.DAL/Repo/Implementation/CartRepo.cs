using Entities;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.DB;
using RG_Store.DAL.Entities;
using RG_Store.DAL.Repo.Abstraction;

namespace RG_Store.DAL.Repo.Implementation
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext context;

        public CartRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddToCart(Item itemvm, int cartIdvm)
        {
            try
            {
                CartItem ci = new CartItem();
                ci.CartId = cartIdvm;
                ci.Item = itemvm;


                await context.CartItems.AddAsync(ci);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> ClearCart(int Id)
        {
            try
            {

                var cartItems = context.CartItems.Where(i => i.CartId == Id).ToList();
                context.CartItems.RemoveRange(cartItems);

                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public async Task<IEnumerable<Item>> GetAllItems(int id)
        {

            try
            {

                var items = await context.CartItems
                  .Include(i => i.Item)
                  .Where(i => i.CartId == id)
                  .Select(i => i.Item)
                  .ToListAsync();
                return items;
            }
            catch (Exception)
            {

                return Enumerable.Empty<Item>().ToList();
            }
        }

        public async Task<Cart> GetById(int id)
        {
            return await context.Carts.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<bool> RemoveFromCart(int itemid, int id)
        {
            try
            {
                var itemToRemove = await context.CartItems
                    .FirstOrDefaultAsync(i => i.CartId == id && i.ItemId == itemid);

                if (itemToRemove != null)
                {
                    context.CartItems.Remove(itemToRemove);
                    await context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
