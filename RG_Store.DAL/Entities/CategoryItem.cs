﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Entities
{
    public class CategoryItem
    {
        public int Id { get; set; } 
        public int CategoryId { get; set; } 
        public Category Category { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
