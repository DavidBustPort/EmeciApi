using Application.Common.Interfaces;

namespace Application.Features.Doctor.Create
{
    public record CreateDoctorCommand(
        string FullName,
        string Email,
        string Password
    ) : IApiRequest<Guid>;
}
