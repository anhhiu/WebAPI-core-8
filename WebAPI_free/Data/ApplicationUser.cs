using Microsoft.AspNetCore.Identity;

namespace WebAPI_free.Data
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}