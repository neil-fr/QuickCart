using Microsoft.AspNetCore.Http;
using QuickCart.Application.DTOs;
using QuickCart.Core.Entities;
using QuickCart.Core.Exceptions;
using QuickCart.Core.Interfaces;

namespace QuickCart.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<ApiResponse<ProductResponseDto>> GetByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product == null)
            throw new ApiException("Product not found", StatusCodes.Status404NotFound);

        var productDto = new ProductResponseDto(
            ProductId: product.ProductId,
            Name: product.Name,
            Description: product.Description,
            Price: product.Price,
            TotalStock: product.TotalStock,
            CreatedAt: product.CreatedAt
        );

        return new ApiResponse<ProductResponseDto>(
            Success: true,
            Message: "Product retrieved successfully",
            Data: productDto
        );
    }

    public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetAllAsync()
    {
        var products = await productRepository.GetAllAsync();

        var productDtos = products.Select(product => new ProductResponseDto(
            product.ProductId,
            product.Name,
            product.Description,
            product.Price,
            product.TotalStock,
            product.CreatedAt
        ));

        return new ApiResponse<IEnumerable<ProductResponseDto>>(
            Success: true,
            Message: "Products retrieved successfully",
            Data: productDtos
        );
    }

    public async Task<ApiResponse<int>> CreateAsync(ProductCreateDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            TotalStock = productDto.TotalStock,
            CreatedAt = DateTime.UtcNow
        };

        var productId = await productRepository.CreateAsync(product);

        return new ApiResponse<int>(
            Success: true,
            Message: "Product created successfully",
            Data: productId
        );
    }

    public Task<ApiResponse<bool>> UpdateAsync(int id, ProductUpdateDto productDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await productRepository.DeleteAsync(id);

        return new ApiResponse<bool>(
            Success: true,
            Message: "Product deleted successfully",
            Data: true
        );
    }
}
