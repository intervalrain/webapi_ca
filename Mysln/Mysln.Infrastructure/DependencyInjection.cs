using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Mysln.Application.Common.Interfaces.Authentication;
using Mysln.Application.Services;
using Mysln.Infrastructure.Authentication;
using Mysln.Infrastructure.Services;
using Mysln.Infrastructure.Persistence;
using Mysln.Application.Persistence;

namespace Mysln.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}