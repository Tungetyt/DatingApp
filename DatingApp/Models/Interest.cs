using System.Collections.Generic;

namespace DatingApp.Models
{
    public class Interest
    {
        public Interest()
        {
            Filter = new HashSet<Filter>();
            UserInterest = new HashSet<UserInterest>();
        }

        public int InterestId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Filter> Filter { get; set; }
        public virtual ICollection<UserInterest> UserInterest { get; set; }
    }
}