using Entities;
using System.ComponentModel.DataAnnotations;

namespace RG_Store.DAL.Entities
{
    public class FavouriteItem
    {
        [Key]
        public int Idt { get; set; }
        public int FavouriteId { get; set; }
        public Favourite Favourite { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
