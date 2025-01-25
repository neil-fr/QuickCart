using QuickCart.Infrastructure.Data;

namespace QuickCart.API.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabaseConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Bind database secrets from configuration
        var secrets = new DatabaseSecrets();
        configuration.GetSection("DatabaseSecrets").Bind(secrets);

        // Register secrets as singleton
        services.AddSingleton(secrets);

        // Register database config
        services.AddSingleton<DatabaseConfig>();

        return services;
    }
}