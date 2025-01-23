using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Attributes;

public class FutureDateAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value,
        ValidationContext context)
    {
        if( value == null) return ValidationResult.Success;

        if (value is DateTime dateTime)
        {
            if (dateTime <= DateTime.UtcNow)
            {
                return new ValidationResult(ErrorMessage ?? "Date must be in the future");
            }
        }
        
        return ValidationResult.Success;
    }
}