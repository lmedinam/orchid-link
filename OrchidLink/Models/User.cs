using Microsoft.AspNetCore.Identity;

namespace OrchidLink.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
