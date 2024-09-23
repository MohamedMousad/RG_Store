using RG_Store.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Item
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal? IntialPrice { get; set; } = 0;
        public decimal? FinalPrice { get; set; } = 0;
        public bool HasOffer { get; set; } = false;
        public decimal? Offer { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        public string? ItemImage { get; set; }

        public IEnumerable<FavouriteItem?> FavouriteItem { get; set; }
        public IEnumerable<CartItem?> CartItem { get; set; }
        public IEnumerable<OrderItem?> OrderItem { get; set; }

        public IEnumerable<CategoryItem?>? CategoryItems { get; set; }
    }
}
