using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;

public record ProductCreateDto(
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Product Name is too long")]
    string Name,
    
    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Product Description is too long")]
    string Description,
    
    [Required(ErrorMessage = "Product Price is required")]
    [PriceRange]
    decimal Price,
    
    int CategoryId,
    
    [Required(ErrorMessage = "Please enter total stock of this product")]
    [StockValidation]
    int TotalStock,
    
    [Required]
    [MinLength(1, ErrorMessage = "At least one image is required")]
    [ValidImageUrl]
    List<string> ImageUrls
);

public record ProductResponseDto(
    int ProductId,
    
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Name is too long")]
    string Name,
    
    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Description is too long")]
    string Description,
    
    [Required(ErrorMessage = "Product Price is required")]
    [PriceRange]
    decimal Price,
    
    [Required(ErrorMessage = "Category name is required")]
    [StringLength(maximumLength:50, ErrorMessage = "Category name is too long")]
    string CategoryName,
    
    [Required(ErrorMessage = "Please enter total stock of this product")]
    [StockValidation]
    int RemainingStock,
    
    bool IsActive,
    
    [Required]
    [MinLength(1, ErrorMessage = "At least one image is required")]
    [ValidImageUrl]
    List<string> ImageUrls,
    
    decimal? CurrentDiscount
);

public record ProductUpdateDto(
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Name is too long")]
    string Name,
    
    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Description is too long")]
    string Description,
    
    [Required(ErrorMessage = "Product Price is required")]
    [PriceRange]
    decimal Price,
    
    int CategoryId,
    
    [Required(ErrorMessage = "Please enter total stock of this product")]
    [StockValidation]
    int TotalStock,
    
    bool IsActive
);