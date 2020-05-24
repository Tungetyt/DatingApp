using System;
using System.Collections.Generic;

namespace DatingApp.Models
{
    public partial class City
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
