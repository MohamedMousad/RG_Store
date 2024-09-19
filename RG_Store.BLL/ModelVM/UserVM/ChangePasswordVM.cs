using System.ComponentModel.DataAnnotations;

namespace RG_Store.BLL.ModelVM.UserVM
{
    public class ChangePasswordVM
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        [MinLength(8, ErrorMessage = "The new password must be at least 8 characters long.")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string? ProfileImage { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }


    }
}
