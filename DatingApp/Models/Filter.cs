using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public partial class Filter
    {
        [Key]
        public string UserId { get; set; }
        public int? MaxSearchDistance { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public int? UniversityId { get; set; }
        public int? InterestId { get; set; }

        public virtual Interest Interest { get; set; }
        public virtual University University { get; set; }
        public virtual User User { get; set; }
    }
}
