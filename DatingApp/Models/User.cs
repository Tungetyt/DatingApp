using System;
using System.Collections.Generic;

namespace DatingApp.Models
{
    public class User : Person
    {
        public User()
        {
            MatchedUsersUserId1Navigation = new HashSet<MatchedUsers>();
            MatchedUsersUserId2Navigation = new HashSet<MatchedUsers>();
            UniversityAttendance = new HashSet<UniversityAttendance>();
            UserInterest = new HashSet<UserInterest>();
            UsersRelationActiveUser = new HashSet<UsersRelation>();
            UsersRelationPassiveUser = new HashSet<UsersRelation>();
        }

        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Description { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Filter Filter { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual UserTracking UserTracking { get; set; }
        public virtual ICollection<MatchedUsers> MatchedUsersUserId1Navigation { get; set; }
        public virtual ICollection<MatchedUsers> MatchedUsersUserId2Navigation { get; set; }
        public virtual ICollection<UniversityAttendance> UniversityAttendance { get; set; }
        public virtual ICollection<UserInterest> UserInterest { get; set; }
        public virtual ICollection<UsersRelation> UsersRelationActiveUser { get; set; }
        public virtual ICollection<UsersRelation> UsersRelationPassiveUser { get; set; }
    }
}