using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RG_Store.DAL.DB;
using RG_Store.DAL.Entities;

namespace RG_Store.Services.Implementation
{
    public class CustomUserManager : UserManager<User>
    {
        private readonly ApplicationDbContext _context;

        public CustomUserManager(
            IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger,
            ApplicationDbContext context)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _context = context;
        }

        public override async Task<IdentityResult> CreateAsync(User user, string password)
        {
            var result = await base.CreateAsync(user, password);

            if (result.Succeeded)
            {
                /* var favourite = new Favourite();
                 _context.Favourites.Add(favourite);
                 await _context.SaveChangesAsync();*//*
                 user.Favourite = favourite;*/
                var cart = new Cart();
                _context.Carts.Add(cart);
                cart.UserId = user.Id;
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
                user.CartId = cart.Id;
                user.Cart = cart;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                var fav = new Favourite();
                _context.Favourites.Add(fav);
                fav.UserId = user.Id;
                _context.Favourites.Add(fav);
                await _context.SaveChangesAsync();
                user.FavouriteId = fav.Id;
                user.Favourite = fav;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
