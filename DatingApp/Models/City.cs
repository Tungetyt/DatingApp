using System.Collections.Generic;

namespace DatingApp.Models
{
    public class City
    {
        public City()
        {
            User = new HashSet<User>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}