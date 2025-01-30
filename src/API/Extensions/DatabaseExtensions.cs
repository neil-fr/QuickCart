using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickCart.Infrastructure.Data;

namespace QuickCart.API.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabaseConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var databaseConfig = new DatabaseConfig
        {
            ConnectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found."
                ),
        };

        services.AddSingleton(databaseConfig);
        return services;
    }
}
