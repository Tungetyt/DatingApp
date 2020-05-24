using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace DatingApp.Models
{
    public partial class UserTracking
    {
        public string UserId { get; set; }
        public int Popularity { get; set; }
        public int ActivityIntensity { get; set; }
        public Geometry Localisation { get; set; }

        public virtual User User { get; set; }
    }
}
