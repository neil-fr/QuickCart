using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;

public abstract record WishlistItemResponseDto(
    int ProductId,
    
    [Required (ErrorMessage = "Product name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product name is too long")]
    string ProductName,
    
    [Required (ErrorMessage = "Product price is required")]
    [PriceRange]
    decimal Price,
    
    [Required (ErrorMessage = "Product image URL is required")]
    [ValidImageUrl]
    string ImageUrl,
    
    [DiscountValidation]
    decimal? CurrentDiscount,
    
    [DataType(DataType.DateTime)]
    DateTime AddedAt
);

public record WishlistResponseDto(
    List<WishlistItemResponseDto> Items
);