using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using System.Security.Claims;

namespace RG_Store.PLL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IItemService ItemService;
        public AdminController(IUserService userService, IItemService ItemService)
        {
            this._userService = userService;
            this.ItemService = ItemService;
            
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            //ViewBag.UserName = username;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]

        public async Task<IActionResult> Users()
        {
            
            var users = await _userService.GetAll(); 
            return View(users.ToList()); 
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("admin/EditUser/{userid}")]
        public async Task<IActionResult> EditUser(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return BadRequest("User ID is required.");
            }
            var user = await _userService.GetUserVM(userid);

            if (user == null)
            {
                return NotFound($"User with ID '{userid}' not found.");
            }
            UpdateRoleVM model = new()
            {
                UserId = userid,
                UserName = user.UserName,
                FirstName = user.FirstName,
                Email = user.Email,
                LastName = user.LastName,
                UserRole = (user.UserRole.Value)  
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditUser(UpdateRoleVM model)
        {
           /* if (!ModelState.IsValid)
            {
                // Return the same view with the existing model if validation fails
                return View(model);
            }
*/


            var res = await _userService.UpdateRole(model, model.UserRole); 
            Console.WriteLine($"Update Result: {res}");

            if (res)
            {
                return RedirectToAction("Index","Admin"); 
            }

            ModelState.AddModelError(string.Empty, "Failed to update user role.");
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("admin/Delete/{userid}")]
        public async Task<IActionResult> Delete(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return BadRequest("User ID is required.");
            }
            var user = await _userService.GetUserVM(userid);

            if (user == null)
            {
                return NotFound($"User with ID '{userid}' not found.");
            }
            DeleteUserVM model = new()
            {
                Id = userid,
                UserName = user.UserName,
                FirstName = user.FirstName,
                Email = user.Email,
                LastName = user.LastName,
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteUserVM model)
        {
            /* if (!ModelState.IsValid)
             {
                 // Return the same view with the existing model if validation fails
                 return View(model);
             }
 */
            var res = await _userService.DeleteUser(model);
            Console.WriteLine($"Update Result: {res}");

            if (res)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Failed to Delete user .");
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Categories()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> items()
        {
            var items =await ItemService.GetAll();
            return View(items.ToList());
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateItem()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateItem(CreateItemVM model)
        {
            var res =await ItemService.Create(model);
            if (res)
            {
                return RedirectToAction("Items", "Admin");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateItem(int id)
        {
            var item =await ItemService.GetAllItem(id);
            UpdateItemVM model = new();
            model.Id = id;
            model.Name = item.Name;
            model.Description = item.Description;
            model.IntialPrice = item.IntialPrice;
            model.FinalPrice = item.FinalPrice;
            model.Quantity = item.Quantity;
            model.Image = model.Image;

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateItem(UpdateItemVM model)
        {
            
            var res = await ItemService.Update(model);
            if (res)
            {
                return RedirectToAction("Items", "Admin");
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item =await ItemService.GetAllItem(id);
            DeleteItemVM model = new();
            model.Id = id;
            model.Name = item.Name;
            model.Description = item.Description;
            model.IntialPrice = item.IntialPrice;
            model.FinalPrice = item.FinalPrice;
            model.Quantity = item.Quantity;
            model.Image = model.Image;

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItem(DeleteItemVM model)
        {
            
            var res = await ItemService.Delete(model);
            if (res)
            {
                return RedirectToAction("Items", "Admin");
            }
            return View(model);
        }
    }
}