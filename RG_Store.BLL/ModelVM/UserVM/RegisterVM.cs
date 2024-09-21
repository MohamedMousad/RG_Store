using RG_Store.DAL.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RG_Store.BLL.ModelVM.UserVM
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(20, ErrorMessage = "ERROR: Max Length 20.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(20, ErrorMessage = "ERROR: Max Length 20.")]
        [MinLength(2, ErrorMessage = "ERROR: Min Length 2.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(20, ErrorMessage = "ERROR: Max Length 20.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; } = Gender.Male;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public Roles UserRole { get; set; } = Roles.Customer;

        /*[Required(ErrorMessage = "Phone Number is required.")]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }*/

        [Required(ErrorMessage = "Email Address is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Format.")]
        public string Email { get; set; } = string.Empty;
    }
}