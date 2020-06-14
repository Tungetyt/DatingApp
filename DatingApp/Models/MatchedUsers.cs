using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class MatchedUsers
    {
        public MatchedUsers()
        {
            Message = new HashSet<Message>();
        }

        [Key] public string UserId1 { get; set; }

        [Key] public string UserId2 { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual User UserId1Navigation { get; set; }
        public virtual User UserId2Navigation { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}