using System.Data.SqlClient;

namespace QuickCart.Infrastructure.Data;

public class DatabaseHealthCheck(DatabaseConfig config)
{
    [Obsolete("Obsolete")]
    public async Task<bool> TestConnectionAsync()
    {
        try
        {
            await using var connection = new SqlConnection(config.ConnectionString);
            await connection.OpenAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}