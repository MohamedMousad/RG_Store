using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; } = 0;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime ?DeletedAt { get; set; } 

        public IEnumerable<Item>? Items { get; set; }

        public bool IsDeleted { get; set; } = false;




    }
}
