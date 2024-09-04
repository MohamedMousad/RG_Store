using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Pro.Models
{
    public class Userlogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Email must be at least 6 characters long.")]
        public string useremail { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Password must be at least 4 characters long.")]
        public string userpassword { get; set; }
    }
}
