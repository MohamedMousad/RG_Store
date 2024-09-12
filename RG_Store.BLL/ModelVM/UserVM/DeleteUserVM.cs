using RG_Store.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.ModelVM.UserVM
{
    public class DeleteUserVM
    {
      public string UserId { get; set; }
      public string UserName { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public Roles UseRrole { get; set; }
      public string Image { get; set; }
    }
}
