using System.ComponentModel.DataAnnotations;

namespace MvcApp.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username / Email Address")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}