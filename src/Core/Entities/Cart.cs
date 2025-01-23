using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Entities;

public class Cart
{
    public int CartId { get; set; }
    public int? UserId { get; set; }
    
    [StringLength(100)]
    [RegularExpression(@"^[A-Za-z0-9-]+$", 
        ErrorMessage = "Session ID can only contain letters, numbers, and hyphens")]
    public string? SessionId { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public User? User { get; set; }
    public ICollection<CartItem> Items { get; set; }
}