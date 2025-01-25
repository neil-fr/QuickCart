using System.Data.SqlClient;

namespace QuickCart.Infrastructure.Data.Repositories;

public abstract class BaseRepository(DatabaseConfig config)
{
    private readonly string _connectionString = config.ConnectionString;

    [Obsolete("Obsolete")]
    protected SqlConnection CreateConnection() => new SqlConnection(_connectionString);
}