using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.DAL.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public decimal TotalPrice { get; set; } = 0;

        // DB relation
        public string UserId { get; set; } 
        public User User { get; set; }

        public IEnumerable<CartItem?> CartItem { get; set; }

    }
}
