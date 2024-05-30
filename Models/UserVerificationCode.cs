namespace Hotel.org.Models
{
    public class UserVerificationCode
    {

        public int Id { get; set; }


        public string UserId { get; set; }

        public User user { get; set; }

        public string Code { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
