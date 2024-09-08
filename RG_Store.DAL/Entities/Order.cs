using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RG_Store.DAL.Enums;
using Microsoft.Extensions.Options;
using RG_Store.DAL.Entities;

namespace Entities
{
    public class Order
    {
/*        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        // Prop
        public int Id { get; set; }
        public DateTime OrederDate { get; set; } = DateTime.Now;
        public decimal TotalCost { get; set; } = 0;
        public decimal DeliveryCost { get; set; } = 0;
        public OrderStatus OrderStatus { get; set; }=OrderStatus.pending;

        public int UserId { get; set; } 
        public User User { get; set; }
        
        public IEnumerable<Item> Items { get; set; }

        public int ?DelivaryId { get; set; } 
        public Delivery ?Delivary { get; set; }
        // Relations
        
       /* public int userid { get; set; }

        public virtual User Users { get; set; }
        public virtual Item Items { get; set; }

        public int itemId { get; set; }*/
    }
}
