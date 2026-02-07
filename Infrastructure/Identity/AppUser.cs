using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public sealed class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
