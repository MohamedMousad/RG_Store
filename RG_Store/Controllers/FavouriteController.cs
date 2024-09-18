using Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;
using RG_Store.DAL.Entities;

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
        public async Task<IActionResult>RemoveFromFavourite(int itemid)
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
