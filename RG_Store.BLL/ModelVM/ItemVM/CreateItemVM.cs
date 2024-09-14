using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
namespace RG_Store.BLL.ModelVM.ItemVM
{
    public class CreateItemVM
    {
        [Required(ErrorMessage = "Please enter the product name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the product description.")]
        public string Description { get; set; }
      

        [Required(ErrorMessage = "Please enter the product price.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal IntialPrice { get; set; }

        [Required(ErrorMessage = "Please enter the initial  quantity.")]
        [Range(0, int.MaxValue, ErrorMessage = "quantity must be a positive number.")]
        public int Quantity { get; set; } = 0;

        public IFormFile ?ItemImage { get; set; }
        
    }
}
