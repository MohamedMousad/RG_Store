namespace RG_Store.BLL.ModelVM.UserVM
{
    public class LoginVM
    {
        public int Id { get; set; }
        /*   [Required(ErrorMessage = "Email address is required")]
           [EmailAddress(ErrorMessage = "Invalid Email Address")]*/
        public string Email { get; set; }
        /*[Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]*/
        public string Password { get; set; }
    }
}
