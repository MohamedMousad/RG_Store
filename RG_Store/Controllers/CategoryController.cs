using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.ModelVM.CategoryVM;
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
       
    }
}
