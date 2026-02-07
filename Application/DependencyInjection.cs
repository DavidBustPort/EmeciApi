using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Behaviors;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(m => {
                m.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
                m.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
