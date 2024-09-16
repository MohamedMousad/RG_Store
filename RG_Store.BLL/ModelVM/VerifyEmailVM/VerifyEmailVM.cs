using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.ModelVM.VerifyEmailVM
{
    public class VerifyEmailVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Confirmation code is required.")]
        public string ConfirmationCode { get; set; }
        public string? Code { get; set; }
    }
}
