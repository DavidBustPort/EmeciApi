using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetByIdAsync(Guid id);
        Task AddAsync(Doctor doctor);
    }
}
