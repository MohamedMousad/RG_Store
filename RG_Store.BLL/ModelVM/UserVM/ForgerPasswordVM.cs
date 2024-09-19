using System.ComponentModel.DataAnnotations;

namespace RG_Store.BLL.ModelVM.UserVM
{
    public class ForgerPasswordVM
    {
        public class ForgotPasswordVM
        {
            public string Email { get; set; }
        }

        public class ResetPasswordVM
        {
            public string Email { get; set; }
            public string Token { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The passwords do not match.")]
            public string ConfirmPassword { get; set; }
        }
    }
}
