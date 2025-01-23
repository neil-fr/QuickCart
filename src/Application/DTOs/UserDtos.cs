using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;

public record UserRegistrationDto(
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(ValidationConstants.MaxEmailLength, ErrorMessage = "Email is too long")]
    string Email,
    
    [Required]
    [StrongPassword]
    string Password,
    
    [Required(ErrorMessage = "First name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "First name is too long")]
    string FirstName,
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Last name is too long")]
    string LastName,
    
    [StringLength(ValidationConstants.MaxPhoneLength, ErrorMessage = "Phone number is too long")]
    string? PhoneNumber
);

public record UserLoginDto(
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(ValidationConstants.MaxEmailLength, ErrorMessage = "Email is too long")]
    string Email,
    
    [Required]
    [StrongPassword]
    string Password
);

public record UserProfileDto(
    int UserId,
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(ValidationConstants.MaxEmailLength, ErrorMessage = "Email is too long")]
    string Email,
    
    [Required(ErrorMessage = "First name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "First name is too long")]
    string FirstName,
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Last name is too long")]
    string LastName,
    
    [StringLength(ValidationConstants.MaxPhoneLength, ErrorMessage = "Phone number is too long")]
    string? PhoneNumber,
    
    [DataType(DataType.DateTime)]
    DateTime CreatedAt
);