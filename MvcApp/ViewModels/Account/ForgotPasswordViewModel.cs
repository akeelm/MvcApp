
using System.ComponentModel.DataAnnotations;

namespace MvcApp.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}