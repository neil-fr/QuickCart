using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Constants;

namespace QuickCart.Core.Entities;

public class Address
{
    public int AddressId { get; set; }
    public int UserId { get; set; }
    
    [Required (ErrorMessage = "Address Line 1 is required")]
    [StringLength(ValidationConstants.MaxAddressLineLength, 
        MinimumLength = ValidationConstants.MinAddressLineLength, ErrorMessage = "Address Line 1 must be at least {2} characters")]
    public string AddressLine1 { get; set; }
    
    [Required (ErrorMessage = "Address Line 2 is required")]
    [StringLength(ValidationConstants.MaxAddressLineLength, 
        MinimumLength = ValidationConstants.MinAddressLineLength, ErrorMessage = "Address Line 2 must be at least {2} characters")]
    public string? AddressLine2 { get; set; }
    
    [Required (ErrorMessage = "City is required")]
    [StringLength(ValidationConstants.MaxCityLength, 
        MinimumLength = ValidationConstants.MinCityLength, ErrorMessage = "City must be at least {2} characters")]
    public string City { get; set; }
    
    [Required (ErrorMessage = "State is required")]
    [StringLength(ValidationConstants.MaxStateLength, MinimumLength = ValidationConstants.MinStateLength,
        ErrorMessage = "State must be at least {2} characters")]
    public string State { get; set; }
    
    [Required (ErrorMessage = "Postal Code is required")]
    [StringLength(ValidationConstants.MinPostalCodeLength, MinimumLength = ValidationConstants.MinPostalCodeLength,
        ErrorMessage = "Postal Code must be at least {1} characters")]
    public string PostalCode { get; set; }
    
    public bool IsDefault { get; set; }

    // Navigation property
    public User User { get; set; }
}