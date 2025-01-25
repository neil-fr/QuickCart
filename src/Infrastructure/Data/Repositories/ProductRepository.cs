using Dapper;
using QuickCart.Application.DTOs;
using QuickCart.Core.Entities;
using QuickCart.Core.Interfaces;

namespace QuickCart.Infrastructure.Data.Repositories;

public class ProductRepository(DatabaseConfig config)
    : BaseRepository(config), IProductRepository
{
    [Obsolete("Obsolete")]
    public async Task<Product?> GetByIdAsync(int id)
    {
        await using var connection = CreateConnection();
        const string sql =
            """
            
                        SELECT p.*, c.Name as CategoryName 
                        FROM Products p
                        LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                        WHERE p.ProductId = @Id AND p.IsActive = 1
            """;
        var product = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
        if (product != null)
        {
            // product images
            const string imageSql = "SELECT * FROM ProductImages WHERE ProductId = @ProductId";
            var images = await connection.QueryAsync<ProductImage>(
                imageSql,
                new { ProductId = id }
            );
            product.Images = images.ToList();
            // discount if any
            const string discountSql =
                @"
                SELECT TOP 1 * FROM Discounts 
                WHERE ProductId = @ProductId 
                AND StartDate <= GETUTCDATE() 
                AND EndDate >= GETUTCDATE() 
                AND IsActive = 1";
            product.Discounts = (
                await connection.QueryAsync<Discount>(discountSql, new { ProductId = id })
            ).ToList();
        }
        return product;
    }

    [Obsolete("Obsolete")]
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        await using var connection = CreateConnection();
        const string sql =
            """
            
                        SELECT p.*, c.Name as CategoryName 
                        FROM Products p
                        LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                        WHERE p.IsActive = 1
            """;

        return await connection.QueryAsync<Product>(sql);
    }

    [Obsolete("Obsolete")]
    public async Task<int> CreateAsync(Product entity)
    {
        await using var connection = CreateConnection();
        const string sql =
            """
            
                        INSERT INTO Products (Name, Description, Price, CategoryId, TotalStock, RemainingStock, CreatedAt, IsActive)
                        VALUES (@Name, @Description, @Price, @CategoryId, @TotalStock, @RemainingStock, GETUTCDATE(), @IsActive);
                        SELECT CAST(SCOPE_IDENTITY() as int)
            """;

        return await connection.QuerySingleAsync<int>(sql, entity);
    }

    public Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> SearchAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateStockAsync(int productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetActiveDiscountsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResponseDto<Product>> GetPaginatedAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
