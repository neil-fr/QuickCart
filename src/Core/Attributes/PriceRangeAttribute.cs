namespace QuickCart.Core.Attributes;

using System.ComponentModel.DataAnnotations;
using Constants;

public class PriceRangeAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is decimal price)
        {
            if (
                price < ValidationConstants.MinProductPrice
                || price > ValidationConstants.MaxProductPrice
            )
                return new ValidationResult(
                    $"Price must be between {ValidationConstants.MinProductPrice:C} and {ValidationConstants.MaxProductPrice:C}"
                );
        }
        return ValidationResult.Success;
    }
}
