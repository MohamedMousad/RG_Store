namespace Entities
{
    public class User
    {
        public int userId { get; set; }

        public string userName { get; set; }

        public string userAddress { get; set; }

        public string userPhone { get; set; }

        public string userGender { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}