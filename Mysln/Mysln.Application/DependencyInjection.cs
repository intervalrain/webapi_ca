using Microsoft.Extensions.DependencyInjection;
using Mysln.Application.Services.Authentication;

namespace Mysln.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;   
    }
}