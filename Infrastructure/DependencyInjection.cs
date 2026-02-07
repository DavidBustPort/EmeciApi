using Application.Common.Interfaces;
using Domain.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connnectionString = configuration.GetConnectionString("defaultConnection");

            services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql(connnectionString, x => x.MigrationsAssembly("Infrastructure"))
            );
            services.AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
