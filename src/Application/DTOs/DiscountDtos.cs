using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;

public record DiscountCreateDto(
    int ProductId,
    
    [Required (ErrorMessage = "Discount percentage is required")]
    [DiscountValidation]    
    decimal DiscountPercentage,
    
    [Required (ErrorMessage = "Start date is required")]
    [DataType(DataType.DateTime)]
    [FutureDate(ErrorMessage = "Start date must be in the future")]
    DateTime StartDate,
    
    [Required (ErrorMessage = "End date is required")]
    [DataType(DataType.DateTime)]
    [DateGreaterThan("StartDate", ErrorMessage = "End date must be after start date")]
    DateTime EndDate
);

public record DiscountResponseDto(
    int DiscountId,
    int ProductId,
    
    [Required (ErrorMessage = "Product name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product name is too long")]
    string ProductName,
    
    [Required (ErrorMessage = "Discount percentage is required")]
    [DiscountValidation]    
    decimal DiscountPercentage,
    
    [Required (ErrorMessage = "Start date is required")]
    [DataType(DataType.DateTime)]
    [FutureDate(ErrorMessage = "Start date must be in the future")]
    DateTime StartDate,
    
    [Required (ErrorMessage = "End date is required")]
    [DataType(DataType.DateTime)]
    [DateGreaterThan("StartDate", ErrorMessage = "End date must be after start date")]
    DateTime EndDate,
    
    bool IsActive
);