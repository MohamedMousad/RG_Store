using System.ComponentModel.DataAnnotations;

namespace RG_Store.BLL.ModelVM.UserVM
{
    public class ForgerPasswordVM
    {
        public class ForgotPasswordVM
        {
            [Required(ErrorMessage = "Email address is required.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
            public string Email { get; set; }
        }

        public class ResetPasswordVM
        {
            [Required(ErrorMessage = "Email address is required.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            [MinLength(8, ErrorMessage = "The password must be at least 8 characters long.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Please confirm your password.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The passwords do not match.")]
            public string ConfirmPassword { get; set; }

            public string Token { get; set; }
        }
    }
}
