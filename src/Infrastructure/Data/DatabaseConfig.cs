namespace QuickCart.Infrastructure.Data;

public class DatabaseConfig(DatabaseSecrets secrets)
{
    public string ConnectionString { get; } = secrets.BuildConnectionString();
}
