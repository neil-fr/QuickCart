namespace QuickCart.Infrastructure.Data;

public class DatabaseSecrets
{
    private string Server { get; set; } = string.Empty;
    private string Database { get; set; } = string.Empty;
    private string UserId { get; set; } = string.Empty;
    private string Password { get; set; } = string.Empty;

    public string BuildConnectionString()
    {
        return $"Server={Server};Database={Database};"
               + $"User Id={UserId};Password={Password};"
               + "Trusted_Connection=False;"
               + "MultipleActiveResultSets=true;"
               +
               // Enable connection pooling
               "Max Pool Size=100;"
               + "Min Pool Size=5;"
               + "Connection Timeout=30;";
    }
}