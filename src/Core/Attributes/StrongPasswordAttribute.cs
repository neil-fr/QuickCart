namespace QuickCart.Core.Attributes;

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Constants;

public class StrongPasswordAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        var password = value as string;
        if (string.IsNullOrEmpty(password))
            return new ValidationResult("Password cannot be empty");

        var errors = new List<string>();

        if (password.Length < ValidationConstants.MinPasswordLength)
            errors.Add($"Password must be at least {ValidationConstants.MinPasswordLength} characters");

        if (password.Length > ValidationConstants.MaxPasswordLength)
            errors.Add($"Password must not exceed {ValidationConstants.MaxPasswordLength} characters");

        if (!Regex.IsMatch(password, @"[A-Z]"))
            errors.Add("Password must contain at least one uppercase letter");

        if (!Regex.IsMatch(password, @"[a-z]"))
            errors.Add("Password must contain at least one lowercase letter");

        if (!Regex.IsMatch(password, @"[0-9]"))
            errors.Add("Password must contain at least one number");

        if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?"":{}|<>]"))
            errors.Add("Password must contain at least one special character");

        return errors.Count == 0 
            ? ValidationResult.Success 
            : new ValidationResult(string.Join(", ", errors));
    }
}