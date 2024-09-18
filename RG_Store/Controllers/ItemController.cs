using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RG_Store.BLL.Images;
using RG_Store.BLL.ModelVM.ItemVM;
using RG_Store.BLL.Service.Abstraction;
using RG_Store.BLL.Service.Implementation;

namespace RG_Store.PLL.Controllers
{
    public class ItemController:Controller
    {
        private readonly IItemService itemService;
        private readonly ICategoryService categoryService;

        public ItemController(IItemService itemService , ICategoryService categoryService)
        {
            this.itemService = itemService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var res = itemService.GetAll();
            return View(res);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(CreateItemVM itemVM)
        //{
        //    if (!itemService.Create(itemVM))
        //    {
        //        return View(itemVM);
        //    }

        //    return RedirectToAction("Index","Home");
        //} 
        [HttpPost]
        public IActionResult Create(CreateItemVM itemVM)
        {
           
            if (itemVM.Image != null)
            {
               
                var fileName = UploadImage.UploadFile("items", itemVM.Image);

                
                itemVM.ItemImage = fileName;
            }

            
            if (!itemService.Create(itemVM))
            {
                return View(itemVM);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Update()
        {
            var categories = categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateItemVM itemVM)
        {
            if (!itemService.Update(itemVM))
            {
                return View(itemVM);
            }
            
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            var categories = categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Delete(DeleteItemVM itemVM)
        {
            if (!itemService.Delete(itemVM))
            {
                return View(itemVM);
            }

            return RedirectToAction("Index", "Home");
        }



    }
}
