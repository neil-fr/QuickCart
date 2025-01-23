using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Attributes;
using Constants;

public class DiscountValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is decimal discountPercentage)
        {
            if (
                discountPercentage < ValidationConstants.DiscountPercentageMinValue
                || discountPercentage > ValidationConstants.DiscountPercentageMaxValue
            )
                return new ValidationResult(
                    $"Discount percentage must be between {ValidationConstants.DiscountPercentageMinValue} and {ValidationConstants.DiscountPercentageMaxValue}"
                );
        }
        return ValidationResult.Success;
    }
}