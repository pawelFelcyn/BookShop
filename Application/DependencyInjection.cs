using Application.Authentication;
using Application.Services;
using AspNetAuthentication.TokenGeneration;
using Domain.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ITokenGenerator<User>, UserJwtTokenGenerator>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true));

            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
