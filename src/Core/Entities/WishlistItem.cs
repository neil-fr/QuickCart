using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Entities;

public class WishlistItem
{
    public int WishlistId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime AddedAt { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Product Product { get; set; }
}