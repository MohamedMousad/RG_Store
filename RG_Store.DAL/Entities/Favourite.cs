using Entities;
using System.ComponentModel.DataAnnotations;

namespace RG_Store.DAL.Entities
{
    public class Favourite
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<FavouriteItem?> FavouriteItem { get; set; }

    }
}
