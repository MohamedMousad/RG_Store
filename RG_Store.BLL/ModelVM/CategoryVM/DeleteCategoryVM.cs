﻿namespace RG_Store.BLL.ModelVM.Category
{
    public class DeleteCategoryVM
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
