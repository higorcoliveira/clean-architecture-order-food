
using Microsoft.Extensions.DependencyInjection;
using OrderFood.Application.Services.Authentication;

namespace OrderFood.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
