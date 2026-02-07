using Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    internal class IdentityService(UserManager<AppUser> userManager) : IIdentityService
    {
        public async Task<(bool Succeeded, string UserId, string[] Errors)> CreateUserAsync(string email, string password, string fullName)
        {
            var user = new AppUser
            {
                UserName = email,
                Email = email,
                FullName = fullName
            };

            var result = await userManager.CreateAsync(user, password);

            return (
                result.Succeeded,
                user.Id,
                result.Errors.Select(e => e.Description).ToArray()
            );
        }
    }
}
