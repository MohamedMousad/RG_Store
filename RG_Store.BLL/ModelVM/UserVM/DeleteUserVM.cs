using RG_Store.DAL.Enums;

namespace RG_Store.BLL.ModelVM.UserVM
{
    public class DeleteUserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Roles UseRrole { get; set; }
        public string Image { get; set; }
    }
}
