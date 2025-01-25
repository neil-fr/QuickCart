using QuickCart.Application.DTOs;
using QuickCart.Core.Entities;

namespace QuickCart.Core.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> SearchAsync(string searchTerm);
    Task<bool> UpdateStockAsync(int productId, int quantity);
    Task<IEnumerable<Product>> GetActiveDiscountsAsync();
    Task<PaginatedResponseDto<Product>> GetPaginatedAsync(int pageNumber, int pageSize);
}
