using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.Category;
using RG_Store.BLL.Service.Abstraction;
namespace RG_Store.PLL.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryServide categoryServide;

        public CategoryController(ICategoryServide categoryServide)
        {
            this.categoryServide = categoryServide;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddCategoryVM categoryVM )
        {
            if (categoryServide.Create(categoryVM))return RedirectToAction("Index","Home");
            else return View(categoryVM);
        }
    }
}
