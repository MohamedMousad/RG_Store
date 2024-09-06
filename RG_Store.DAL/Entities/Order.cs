using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
        public string orederDate { get; set; }
        public string orderCost { get; set; }
        public string orderDeliveryDate { get; set; }
        
        public virtual User Users { get; set; }
        public int userid { get; set; }

        public virtual Item Items { get; set; }

        public int itemId { get; set; }
    }
}
