using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;

public abstract record AddressCreateDto(
    [Required (ErrorMessage = "Address Line 1 is required")]
    [StringLength(ValidationConstants.MaxAddressLineLength, 
        MinimumLength = ValidationConstants.MinAddressLineLength, ErrorMessage = "Address Line 1 must be at least {2} characters")]
    string AddressLine1,
    
    [Required (ErrorMessage = "Address Line 2 is required")]
    [StringLength(ValidationConstants.MaxAddressLineLength, 
        MinimumLength = ValidationConstants.MinAddressLineLength, ErrorMessage = "Address Line 2 must be at least {2} characters")]
    string? AddressLine2,
    
    [Required (ErrorMessage = "City is required")]
    [StringLength(ValidationConstants.MaxCityLength, 
        MinimumLength = ValidationConstants.MinCityLength, ErrorMessage = "City must be at least {2} characters")]
    string City,
    
    [Required (ErrorMessage = "State is required")]
    [StringLength(ValidationConstants.MaxStateLength, MinimumLength = ValidationConstants.MinStateLength,
        ErrorMessage = "State must be at least {2} characters")]
    string State,
    
    [Required (ErrorMessage = "Postal Code is required")]
    [StringLength(ValidationConstants.MinPostalCodeLength, MinimumLength = ValidationConstants.MinPostalCodeLength,
        ErrorMessage = "Postal Code must be at least {1} characters")]
    string PostalCode,
    
    bool IsDefault
);

public record AddressResponseDto(
    int AddressId,
    
    [Required (ErrorMessage = "Address Line 1 is required")]
    [StringLength(ValidationConstants.MaxAddressLineLength, 
        MinimumLength = ValidationConstants.MinAddressLineLength, ErrorMessage = "Address Line 1 must be at least {2} characters")]
    string AddressLine1,
    
    [Required (ErrorMessage = "Address Line 2 is required")]
    [StringLength(ValidationConstants.MaxAddressLineLength, 
        MinimumLength = ValidationConstants.MinAddressLineLength, ErrorMessage = "Address Line 2 must be at least {2} characters")]
    string? AddressLine2,
    
    [Required (ErrorMessage = "City is required")]
    [StringLength(ValidationConstants.MaxCityLength, 
        MinimumLength = ValidationConstants.MinCityLength, ErrorMessage = "City must be at least {2} characters")]
    string City,
    
    [Required (ErrorMessage = "State is required")]
    [StringLength(ValidationConstants.MaxStateLength, MinimumLength = ValidationConstants.MinStateLength,
        ErrorMessage = "State must be at least {2} characters")]
    string State,
    
    [Required (ErrorMessage = "Postal Code is required")]
    [StringLength(ValidationConstants.MinPostalCodeLength, MinimumLength = ValidationConstants.MinPostalCodeLength,
        ErrorMessage = "Postal Code must be at least {1} characters")]
    string PostalCode,
    
    bool IsDefault
);