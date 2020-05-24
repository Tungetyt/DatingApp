using System;
using System.Collections.Generic;

namespace DatingApp.Models
{
    public partial class UniversityAttendance
    {
        public string UserId { get; set; }
        public int UniversityId { get; set; }
        public bool? IsGraduated { get; set; }
        public string FieldOfStudy { get; set; }

        public virtual University University { get; set; }
        public virtual User User { get; set; }
    }
}
