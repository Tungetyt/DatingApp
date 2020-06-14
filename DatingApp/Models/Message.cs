using System;

namespace DatingApp.Models
{
    public class Message
    {
        public string SenderUserId { get; set; }
        public string RecieverUserId { get; set; }
        public int MessageId { get; set; }
        public string Message1 { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual MatchedUsers MatchedUsers { get; set; }
    }
}