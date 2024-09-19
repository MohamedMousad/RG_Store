using System.ComponentModel.DataAnnotations;

namespace RG_Store.BLL.ModelVM.Category
{
    public class AddCategoryVM
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
    }
}
