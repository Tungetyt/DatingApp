using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Models;

namespace DatingApp.ViewModels
{
    public class ProfileToShowInMatching
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Gender { get; set; }
        public string Description { get; set; }

        public List<University> Universities { get; set; }
    }
}
