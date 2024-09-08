using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RG_Store.DAL.Enums;

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


        // Relations
        
       /* public int userid { get; set; }

        public virtual User Users { get; set; }
        public virtual Item Items { get; set; }

        public int itemId { get; set; }*/
    }
}
