using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Attributes;

public class ValidImageUrlAttribute : ValidationAttribute
{
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uriResult))
                return new ValidationResult("Invalid URL format");

            var extension = Path.GetExtension(uriResult.LocalPath).ToLower();
            if (!_allowedExtensions.Contains(extension))
                return new ValidationResult($"Only {string.Join(", ", _allowedExtensions)} images are allowed");
        }
        return ValidationResult.Success;
    }
}