﻿using Microsoft.AspNetCore.Http;
namespace RG_Store.BLL.ModelVM.ItemVM
{
    public class CreateItemVM
    {
        /* [Required(ErrorMessage = "Please enter the product name.")]*/
        public string Name { get; set; }
        /*
                [Required(ErrorMessage = "Please enter the product description.")]*/
        public string? Description { get; set; }


        /* [Required(ErrorMessage = "Please enter the product price.")]
         [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]*/
        public decimal IntialPrice { get; set; }
        public decimal FinalPrice { get; set; }

        /*[Required(ErrorMessage = "Please enter the initial  quantity.")]
        [Range(0, int.MaxValue, ErrorMessage = "quantity must be a positive number.")]*/
        public int Quantity { get; set; } = 0;
        public int? CategoryId { get; set; }
        public IFormFile? Image { get; set; }
        public string? ItemImage { get; set; }


    }
}
