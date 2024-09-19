using System.ComponentModel.DataAnnotations;

namespace RG_Store.BLL.ModelVM.Category
{
    public class UpdateCategoryVM
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
