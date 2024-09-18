using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RG_Store.DAL.Enums;
using Microsoft.Extensions.Options;
using RG_Store.DAL.Entities;

namespace Entities
{
    public class Order
    {
        [Key] 
        
        public int Id { get; set; }
        public DateTime OrederDate { get; set; } = DateTime.Now;
        public decimal TotalCost { get; set; } = 0;
        public OrderStatus OrderStatus { get; set; }=OrderStatus.pending;

        public string UserId { get; set; } 
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
