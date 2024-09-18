using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;

namespace RG_Store.PLL.Controllers
{
    public class FavouriteController : Controller
    {
        IFavouriteService favouriteService;
        UserManager<User> userManager;

        public FavouriteController(IFavouriteService favouriteService,UserManager<User> userManager)
        {
            this.favouriteService = favouriteService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            var res = await favouriteService.GetAll(id);
            var ret = res.ToList();
            return View(ret);
        }
        [HttpPost]
        public async Task<IActionResult>AddToFavourite(int itemid)
        {
            var user = await userManager.GetUserAsync(User);

            var cartId = user.FavouriteId;
          await  favouriteService.AddToFavorite(itemid,cartId??0);
         return RedirectToAction("Index", "Favourite", new { id = cartId });
        }
        public async Task<IActionResult>RemoveFromFavourite(int itemid)
        {
            var user = await userManager.GetUserAsync(User);

            var cartId = user.FavouriteId;
          await  favouriteService.RemoveFromFavorite(itemid,cartId??0);
         return RedirectToAction("Index", "Favourite", new { id = cartId });
        }
    }
}
