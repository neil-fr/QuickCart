using QuickCart.Application.DTOs;

namespace QuickCart.Application.Services;

public interface IProductService
{
    Task<ApiResponse<ProductResponseDto>> GetByIdAsync(int id);
    Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetAllAsync();
    Task<ApiResponse<int>> CreateAsync(ProductCreateDto productDto);
    Task<ApiResponse<bool>> UpdateAsync(int id, ProductUpdateDto productDto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
    
}