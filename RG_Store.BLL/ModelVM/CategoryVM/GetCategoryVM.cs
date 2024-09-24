namespace RG_Store.BLL.ModelVM.CategoryVM
{
    public class GetCategoryVM
    {

        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
