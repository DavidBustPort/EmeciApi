using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class DoctorRepository(AppDbContext context) : IDoctorRepository
    {
        public async Task AddAsync(Doctor doctor)
        {
            await context.Doctors.AddAsync(doctor);
        }

        public Task<Doctor?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
