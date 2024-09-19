using Entities;
using System.ComponentModel.DataAnnotations;

namespace RG_Store.DAL.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }


        public Order Order { get; set; }
        public Item Item { get; set; }
    }
}
