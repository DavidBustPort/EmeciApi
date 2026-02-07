namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(bool Succeeded, string UserId, string[] Errors)> CreateUserAsync(
            string email,
            string password,
            string fullName
        );
    }
}
