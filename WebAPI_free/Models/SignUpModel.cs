using System.ComponentModel.DataAnnotations;

namespace WebAPI_free.Models
{
    public class SignUpModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PassWord { get; set; } = string.Empty;
        [Required]
        public string ComFirmPassword { get; set; } = string.Empty;
    }
}
