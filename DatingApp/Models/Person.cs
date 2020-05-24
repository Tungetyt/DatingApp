using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.Models
{
    public partial class Person : IdentityUser
    {
        [Key]
        public string PersonId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }


    }
}
