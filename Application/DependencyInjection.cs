using Application.Authentication;
using Application.Services;
using AspNetAuthentication.TokenGeneration;
using Domain.Entities;
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

            return services;
        }
    }
}
