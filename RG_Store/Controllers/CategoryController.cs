using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.Category;
using RG_Store.BLL.Service.Abstraction;
namespace RG_Store.PLL.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddCategoryVM categoryVM)
        {
            if (categoryService.Create(categoryVM)) return RedirectToAction("Index", "Home");
            else return View(categoryVM);
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateCategoryVM categoryVM)
        {
            if (categoryService.Update(categoryVM)) return RedirectToAction("Index", "Home");
            else return View(categoryVM);
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(DeleteCategoryVM categoryVM)
        {
            if (categoryService.Delete(categoryVM)) return RedirectToAction("Index", "Home");
            else return View(categoryVM);
        }
    }
}
