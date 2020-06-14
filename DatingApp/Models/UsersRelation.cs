using System;

namespace DatingApp.Models
{
    public class UsersRelation
    {
        public string ActiveUserId { get; set; }
        public string PassiveUserId { get; set; }
        public bool IsLiking { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User ActiveUser { get; set; }
        public virtual User PassiveUser { get; set; }
    }
}