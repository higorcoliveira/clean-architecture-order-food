
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderFood.Infrastructure.Services;
using OrderFood.Infrastructure.Persistence;
using OrderFood.Infrastructure.Authentication;
using OrderFood.Application.Common.Interfaces.Services;
using OrderFood.Application.Common.Interfaces.Persistence;
using OrderFood.Application.Common.Interfaces.Authentication;

namespace OrderFood.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
