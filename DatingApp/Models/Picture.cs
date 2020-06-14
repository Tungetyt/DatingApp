namespace DatingApp.Models
{
    public class Picture
    {
        public string UserId { get; set; }
        public byte[] Picture1 { get; set; }
        public int Order { get; set; }

        public virtual User User { get; set; }
    }
}