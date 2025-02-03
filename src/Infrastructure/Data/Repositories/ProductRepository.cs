using Dapper;
using QuickCart.Core.Entities;
using QuickCart.Core.Interfaces;

namespace QuickCart.Infrastructure.Data.Repositories;

public class ProductRepository(DatabaseConfig config) : BaseRepository(config), IProductRepository
{
    public async Task<Product?> GetByIdAsync(int id)
    {
        await using var connection = CreateConnection();
        const string sql = "SELECT p.* FROM Products p WHERE p.ProductId = @Id";
        var product = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        await using var connection = CreateConnection();
        const string sql = "SELECT p.* FROM Products p";

        return await connection.QueryAsync<Product>(sql);
    }

    public async Task<int> CreateAsync(Product entity)
    {
        await using var connection = CreateConnection();
        const string sql = """
                INSERT INTO Products (Name, Description, Price, TotalStock, CreatedAt) 
                VALUES (@Name, @Description, @Price, @TotalStock, @CreatedAt);
                SELECT CAST(SCOPE_IDENTITY() as int);
            """;

        return await connection.QuerySingleAsync<int>(sql, entity);
    }
    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var connection = CreateConnection();
        const string sql = """
                DELETE FROM Products 
                WHERE ProductId = @Id
            """;
        var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }
}
