using System.ComponentModel.DataAnnotations;

namespace Pro.ViewModel
{
    public class CreateOrder
    {
        [Required]

        public int userid { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Write a valid Name", MinimumLength = 3)]
        public string username { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Write a valid Address", MinimumLength = 3)]
        public string useraddress { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Write a valid Phone", MinimumLength = 3)]
        public string userphone { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "Write a Valid Gender", MinimumLength = 4)]
        public string usergender { get; set; }
        [Required]

        public string orederDate { get; set; }
        [Required]
        public string orderCost { get; set; }
        [Required]
        public string orderDeliveryDate { get; set; }
        [Required]
        public int itemid { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Write a valid Item Name", MinimumLength = 3)]
        public string itemName { get; set; }
        [Required]
        public string itemPrice { get; set; }

    }
}
