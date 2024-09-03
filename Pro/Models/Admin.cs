using System.ComponentModel.DataAnnotations;

namespace Pro.Models
{
    public class Admin
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Admin email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string adminemail { get; set; }
        [Required(ErrorMessage = "Admin password is required.")]
        public string adminpassword { get; set; }
    }
}
