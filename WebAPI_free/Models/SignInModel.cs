using System.ComponentModel.DataAnnotations;

namespace WebAPI_free.Models
{
    public class SignInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
