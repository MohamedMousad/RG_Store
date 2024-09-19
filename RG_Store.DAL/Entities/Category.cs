﻿using Entities;
using System.ComponentModel.DataAnnotations;

namespace RG_Store.DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Item?>? Items { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; } = false;
    }
}
