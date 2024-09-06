using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.BLL.ModelVM
{
    public class RegistrationVM
    {
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Passward { get; set; }
    }
}
