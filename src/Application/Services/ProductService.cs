using Microsoft.AspNetCore.Http;
using QuickCart.Application.DTOs;
using QuickCart.Core.Entities;
using QuickCart.Core.Exceptions;
using QuickCart.Core.Interfaces;

namespace QuickCart.Application.Services;

public class ProductService(IProductRepository productRepository)
    : IProductService
{
    public async Task<ApiResponse<ProductResponseDto>> GetByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product == null)
            throw new ApiException("Product not found", StatusCodes.Status404NotFound);

        var discount = product.Discounts.Any()
            ? product.Discounts.First().DiscountPercentage
            : (decimal?)null;

        var productDto = new ProductResponseDto(
            ProductId: product.ProductId,
            Name: product.Name,
            Description: product.Description,
            Price: product.Price,
            CategoryId: product.CategoryId,
            CategoryName: product.Category?.Name ?? string.Empty,
            TotalStock: product.TotalStock,
            RemainingStock: product.RemainingStock,
            ImageUrls: product.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>(),
            DiscountPercentage: discount,
            IsActive: product.IsActive
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
            product.CategoryId,
            product.Category?.Name ?? string.Empty,
            product.TotalStock,
            product.RemainingStock,
            product.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>(),
            product.Discounts.FirstOrDefault()?.DiscountPercentage,
            product.IsActive
        ));

        return new ApiResponse<IEnumerable<ProductResponseDto>>(
            Success: true,
            Message: "Products retrieved successfully",
            Data: productDtos
        );
    }

    public async Task<ApiResponse<int>> CreateAsync(ProductCreateDto productDto)
    {
        // var product = new Product
        // {
        //     Name = productDto.Name,
        //     Description = productDto.Description,
        //     Price = productDto.Price,
        //     CategoryId = productDto.CategoryId,
        //     TotalStock = productDto.TotalStock,
        //     RemainingStock = productDto.TotalStock, // Initially same as TotalStock
        //     CreatedAt = DateTime.UtcNow,
        //     IsActive = true,
        // };
        //
        // // Create product first
        // var productId = await _productRepository.CreateAsync(product);
        //
        // // Then create product images
        // var productImages = new List<ProductImage>();
        // foreach (var (url, index) in productDto.ImageUrls.Select((url, index) => (url, index)))
        // {
        //     productImages.Add(
        //         new ProductImage
        //         {
        //             ProductId = productId,
        //             ImageUrl = url,
        //             IsMain = index == 0, // First image is main
        //         }
        //     );
        // }
        //
        // // Add images to the product
        // await _productRepository.AddProductImagesAsyn(productId, productImages);
        //
        // return new ApiResponse<int>(
        //     Success: true,
        //     Message: "Product created successfully",
        //     Data: productId
        // );
        throw new NotImplementedException();
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
