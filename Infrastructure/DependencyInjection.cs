using Domain.Interfaces;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IEmailValidationHelper, EmailValidationHelper>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
