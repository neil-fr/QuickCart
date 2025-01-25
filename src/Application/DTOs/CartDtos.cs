using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;

public abstract record CartItemDto(
    int ProductId,
    
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(ValidationConstants.MaxNameLength)]
    string ProductName,
    
    [Required (ErrorMessage = "Price is required")]
    [PriceRange]
    decimal Price,
    
    [Required(ErrorMessage = "Quantity is required")]
    int Quantity,
    
    [Required]
    [ValidImageUrl]
    string ImageUrl,
    
    [DiscountValidation]
    decimal? DiscountPercentage
);

public record CartResponseDto(
    int CartId,
    
    [Required (ErrorMessage = "Items are required")]
    [MinLength(1, ErrorMessage = "Cart must have at least one item")]
    List<CartItemDto> Items,
    
    [Required(ErrorMessage = "Total amount is required")]
    decimal TotalAmount,
    
    [DiscountValidation]
    decimal? DiscountedAmount
);