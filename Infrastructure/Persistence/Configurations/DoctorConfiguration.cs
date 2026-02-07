using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .ToTable("Doctor", "medical")
                .HasKey("Id");

            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(d => d.UserId)
                .IsRequired();

            builder.HasOne<AppUser>()
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
