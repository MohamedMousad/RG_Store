using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RG_Store.DAL.Entities;

namespace Entities
{
    public class Item
    {
        /*        [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public bool HasOffer { get; set; }=false;
        public decimal ?Offer { get; set; } = 0;
        public string? ItemImage { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }  
    }
}
