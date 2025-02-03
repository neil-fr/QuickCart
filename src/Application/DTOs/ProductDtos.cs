using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;

public record ProductCreateDto(
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(
        ValidationConstants.MaxNameLength,
        MinimumLength = 4,
        ErrorMessage = "Product Name is too long"
    )]
        string Name,
    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(
        ValidationConstants.MaxNameLength,
        MinimumLength = 4,
        ErrorMessage = "Product Description is too long"
    )]
        string Description,
    [Required(ErrorMessage = "Product Price is required")] [PriceRange] decimal Price,
    [Required(ErrorMessage = "Please enter total stock of this product")]
    [StockValidation]
        int TotalStock,
        DateTime CreatedAt
);

public record ProductResponseDto(
    int ProductId,
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Name is too long")]
        string Name,
    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(
        ValidationConstants.MaxNameLength,
        ErrorMessage = "Product Description is too long"
    )]
    string Description,
    decimal Price,
    int TotalStock,
    DateTime CreatedAt);

public record ProductUpdateDto(
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Name is too long")]
        string Name,
    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(
        ValidationConstants.MaxNameLength,
        ErrorMessage = "Product Description is too long"
    )]
        string Description,
        int Price,
        int TotalStock,
        DateTime CreatedAt
            
);
