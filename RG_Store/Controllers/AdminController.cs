using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.UserVM;
using RG_Store.BLL.Service.Abstraction.RG_Store.BLL.Service.Abstraction;
using System.Security.Claims;

namespace RG_Store.PLL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            //ViewBag.UserName = username;
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> Users()
        {
            
            var users = await _userService.GetAll(); 
            return View(users.ToList()); 
        }

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

        [HttpPost]
        public async Task<IActionResult> EditUser(UpdateRoleVM model)
        {
           /* if (!ModelState.IsValid)
            {
                // Return the same view with the existing model if validation fails
                return View(model);
            }
*/

            Console.WriteLine($"Updating user with ID: {model.UserId}, Role: {model.UserRole}");

            var res = await _userService.UpdateRole(model, model.UserRole);
            Console.WriteLine($"Update Result: {res}");

            if (res)
            {
                return RedirectToAction("Index"); 
            }

            ModelState.AddModelError(string.Empty, "Failed to update user role.");
            return View(model);
        }

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

        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult items()
        {
            return View();
        }

    }
}