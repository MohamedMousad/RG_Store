using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.Service.Abstraction;

namespace RG_Store.PLL.Controllers
{
    public class FavouriteController : Controller
    {
        IFavouriteService favouriteService;
        UserManager<User> userManager;

        public FavouriteController(IFavouriteService favouriteService, UserManager<User> userManager)
        {
            this.favouriteService = favouriteService;
            this.userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user =await userManager.GetUserAsync(User);
            var res = await favouriteService.GetAll(user.FavouriteId??1);
            var ret = res.ToList();
            return View(ret);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToFavourite(int itemid)
        {

            try
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "User not found!";
                    return RedirectToAction("Account", "SignUp");
                }

                var favid = user.FavouriteId;
                if (favid == null)
                {
                    TempData["ErrorMessage"] = "Cart ID is not available!";
                    return RedirectToAction("Index", "Home");
                }

                bool result = await favouriteService.AddToFavorite(itemid, favid ?? 3005);

                if (result)
                {
                    TempData["SuccessMessage"] = "Item added to cart successfully!";
                    return RedirectToAction("Index", "Favourite", new { id = favid });
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to add item to cart!";
                }

                return RedirectToAction("Index", "Favourite", new { id = favid });
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while processing your request.";
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public async Task<IActionResult> RemoveFromFavourite(int itemid)
        {

            var user = await userManager.GetUserAsync(User);


            var favid = user.FavouriteId;

            bool result = await favouriteService.RemoveFromFavorite(itemid, favid ?? 3005);

            if (result)
            {
                TempData["SuccessMessage"] = "Item added to cart successfully!";
                return RedirectToAction("Index", "Favourite", new { id = favid });
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add item to cart!";
                return RedirectToAction("Index", "Favourite", new { id = favid });
            }

        }
    }
}
