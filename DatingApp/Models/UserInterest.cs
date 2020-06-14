namespace DatingApp.Models
{
    public class UserInterest
    {
        public int InterestId { get; set; }
        public string UserId { get; set; }

        public virtual Interest Interest { get; set; }
        public virtual User User { get; set; }
    }
}