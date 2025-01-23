using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;
public record OrderItemDetailDto(
    int OrderItemId,
    int ProductId,
    
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Product name must be between 4 and 100 characters")]
    string ProductName,
    
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Product description must be between 4 and 100 characters")]
    string ProductDescription,
    
    [Required(ErrorMessage = "Product price is required")]
    [PriceRange]
    decimal PriceAtTime,
    
    [DiscountValidation]
    decimal? DiscountAtTime,
    
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 9999, ErrorMessage = "Quantity must be greater than 0")]
    int Quantity
);