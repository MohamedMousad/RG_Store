using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
