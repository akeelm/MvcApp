using Repository.Models;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.ViewModels.Account
{
    public class UserForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}