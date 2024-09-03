using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pro.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemid { get; set; }
        public string itemName { get; set; }
        public string itemPrice { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
