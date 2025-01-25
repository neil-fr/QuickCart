using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Attributes;

public class DateGreaterThanAttribute(string comparisonProperty)
    : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if(value is null) return ValidationResult.Success;

        var currentValue = (DateTime)value;
        var property = context.ObjectType.GetProperty(comparisonProperty);
        if(property is null)
            return new ValidationResult($"Property with name {comparisonProperty} not found");
        
        var comparisonValue = (DateTime)property.GetValue(context.ObjectInstance)!;

        return currentValue > comparisonValue
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage);
    }
}