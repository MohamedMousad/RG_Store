using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.ModelVM.UserVM
{
    public class ForgerPasswordVM
    {
        public class ChangePasswordVM
        {
            public string? Email { get; set; }
            public string NewPassword { get; set; }
        }
    }
}
