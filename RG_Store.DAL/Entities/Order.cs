using RG_Store.DAL.Entities;
using RG_Store.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Order
    {
        [Key]

        public int Id { get; set; }
        public DateTime OrederDate { get; set; } = DateTime.Now;
        public decimal TotalCost { get; set; } = 0;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.pending;

        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
