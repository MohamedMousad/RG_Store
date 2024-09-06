using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemId { get; set; }
        public string itemName { get; set; }
        public int itemPrice { get; set; }
        public string? itemImage { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}
