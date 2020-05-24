using System;
using System.Collections.Generic;

namespace DatingApp.Models
{
    public partial class University
    {
        public University()
        {
            Filter = new HashSet<Filter>();
            UniversityAttendance = new HashSet<UniversityAttendance>();
        }

        public int UniversityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Filter> Filter { get; set; }
        public virtual ICollection<UniversityAttendance> UniversityAttendance { get; set; }
    }
}
