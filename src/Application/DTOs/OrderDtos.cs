using System.ComponentModel.DataAnnotations;

namespace QuickCart.Application.DTOs;

public record OrderCreateDto(
    int AddressId,
    
    [Required (ErrorMessage = "Order items are required")]
    [MinLength(1, ErrorMessage = "Order must have at least one item")]
    List<OrderItemDto> Items
);

public record OrderItemDto(
    int ProductId,
    
    [Required (ErrorMessage = "Quantity is required")]
    [Range(1, 9999, ErrorMessage = "Quantity must be greater than 0")]
    int Quantity
);

public record OrderResponseDto(
    int OrderId,
    string Status,
    
    [Required (ErrorMessage = "Order date is required")]
    [DataType(DataType.DateTime)]
    DateTime OrderDate,
    
    [Required (ErrorMessage = "Total amount is required")]
    [DataType(DataType.Currency)]
    decimal TotalAmount,
    
    [Required (ErrorMessage = "Shipping address is required")]
    AddressCreateDto ShippingAddress,
    
    [Required (ErrorMessage = "Order items are required")]
    [MinLength(1, ErrorMessage = "Order must have at least one item")]
    List<OrderItemDetailDto> Items
);