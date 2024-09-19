using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RG_Store.BLL.ModelVM.ItemVM
{
    public class GetAllItemVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the product name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the product description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the product price.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal IntialPrice { get; set; }
        public decimal FinalPrice { get; set; }
        [Required(ErrorMessage = "Please enter the initial  quantity.")]
        [Range(0, int.MaxValue, ErrorMessage = "quantity must be a positive number.")]
        public int Quantity { get; set; } = 0;
        public IFormFile? Image { get; set; }
        public string? ItemImage { get; set; }
        public bool HasOffer { get; set; } = false;
        public decimal? Offer { get; set; } = 0;
        public int? CategoryId { get; set; }

    }
}
