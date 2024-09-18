﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var res = await itemService.GetAll();
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
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
        public async Task<IActionResult> Create(CreateItemVM itemVM)
        {
           
            if (itemVM.Image != null)
            {
               
                var fileName = UploadImage.UploadFile("items", itemVM.Image);

                
                itemVM.ItemImage = fileName;
            }

            
            if (!await itemService.Create(itemVM))
            {
                return View(itemVM);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var categories = categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Update(UpdateItemVM itemVM)
        {
            if (! await itemService.Update(itemVM))
            {
                return View(itemVM);
            }
            
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var categories = categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteItemVM itemVM)
        {
            if (!await itemService.Delete(itemVM))
            {
                return View(itemVM);
            }

            return RedirectToAction("Index", "Home");
        }



    }
}
