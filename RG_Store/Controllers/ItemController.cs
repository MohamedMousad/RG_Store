using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG_Store.BLL.Images;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;

namespace RG_Store.PLL.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;
        private readonly ICategoryService categoryService;

        public ItemController(IItemService itemService, ICategoryService categoryService)
        {
            this.itemService = itemService;
            this.categoryService = categoryService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var Result = await itemService.GetAll();
            List<GetAllItemVM> view = new();
            foreach (var item in Result)
            {
                if (item.Quantity > 0 && !item.IsDeleted) view.Add(item);
            }
            return View(view);
        }

    }
}
