using Entities;
using System.ComponentModel.DataAnnotations;

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
