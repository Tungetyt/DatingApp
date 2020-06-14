using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class Person
    {
        [Key] public string PersonId { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Name { get; set; }
    }
}