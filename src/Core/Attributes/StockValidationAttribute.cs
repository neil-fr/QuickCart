using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Constants;

namespace QuickCart.Core.Attributes;

public class StockValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is int stock)
        {
            if (stock < ValidationConstants.MinStockQuantity || stock > ValidationConstants.MaxStockQuantity)
                return new ValidationResult(
                    $"Stock must be between {ValidationConstants.MinStockQuantity} and {ValidationConstants.MaxStockQuantity}");
        }
        return ValidationResult.Success;
    }
}