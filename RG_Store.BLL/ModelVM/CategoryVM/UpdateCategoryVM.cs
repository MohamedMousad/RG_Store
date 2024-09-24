using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RG_Store.BLL.ModelVM.CategoryVM
{
    public class UpdateCategoryVM
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? categoryImage { get; set; }
        public IFormFile Image { get; set; }

    }
}
