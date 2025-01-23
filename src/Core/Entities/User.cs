using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Core.Entities;

public class User
{
    public int UserId { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(ValidationConstants.MaxEmailLength, ErrorMessage = "Email is too long")]
    public string Email { get; set; }
    
    [Required]
    [StrongPassword]
    public string PasswordHash { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 2,
        ErrorMessage = "First name is too long")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 2,
        ErrorMessage = "Last name is too long")]
    public string LastName { get; set; }
    
    [StringLength(ValidationConstants.MaxPhoneLength, ErrorMessage = "Phone number is too long")]
    public string? PhoneNumber { get; set; }
    
    public string Role { get; set; } = "Customer";
    
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime? LastLogin { get; set; }
    
    // Navigation properties
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<WishlistItem> WishlistItems { get; set; }
}