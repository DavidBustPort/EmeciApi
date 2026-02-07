using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Doctor.Create
{
    internal sealed class CreateDoctorCommandHandler(
        IIdentityService identityService,
        IDoctorRepository doctorRepository,
        IUnitOfWork unitOfWork
    ) : IApiRequestHandler<CreateDoctorCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                var (succeeded, userId, errors) = await identityService.CreateUserAsync(
                    request.Email,
                    request.Password,
                    request.FullName
                );

                if (!succeeded)
                {
                    throw new ValidationException($"Fallo al crear el usuario: {string.Join(", ", errors)}");
                }

                var doctor = new Domain.Entities.Doctor
                {
                    UserId = userId,
                    FullName = request.FullName
                };
                await doctorRepository.AddAsync(doctor);

                await unitOfWork.CommitAsync(cancellationToken);

                return Result<Guid>.Success(doctor.Id);
            }
            catch
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
