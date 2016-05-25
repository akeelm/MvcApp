using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class User : Base
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime LoginDate { get; set; } = DateTime.UtcNow;
    }
}
