namespace Pro.Models
{
    public class User
    {
        public int userid { get; set; }

        public string username { get; set; }

        public string useraddress { get; set; }

        public string userphone { get; set; }

        public string usergender { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
