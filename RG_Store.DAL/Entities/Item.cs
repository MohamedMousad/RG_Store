using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Item
    {
/*        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public bool HasOffer { get; set; }=false;
        public decimal Offer { get; set; } = 0;
        public string? ItemImage { get; set; }
      //  public virtual List<Order>? Orders { get; set; }
    }
}
