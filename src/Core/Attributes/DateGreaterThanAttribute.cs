using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Attributes;

public class DateGreaterThanAttribute: ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateGreaterThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if(value is null) return ValidationResult.Success;

        var currentValue = (DateTime)value;
        var property = context.ObjectType.GetProperty(_comparisonProperty);
        if(property is null)
            return new ValidationResult($"Property with name {_comparisonProperty} not found");
        
        var comparisonValue = (DateTime)property.GetValue(context.ObjectInstance)!;

        return currentValue > comparisonValue
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage);
    }
}