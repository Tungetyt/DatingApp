using System;
using System.Collections.Generic;

namespace DatingApp.Models
{
    public partial class Picture
    {
        public string UserId { get; set; }
        public byte[] Picture1 { get; set; }
        public int Order { get; set; }

        public virtual User User { get; set; }
    }
}
