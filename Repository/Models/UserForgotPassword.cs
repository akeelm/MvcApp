using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class UserForgotPassword : Base
    {
        public int UserID { get; set; }
        [Required]
        public string Code { get; set; }

        public User User { get; set; }
    }
}
