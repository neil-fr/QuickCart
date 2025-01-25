using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Entities;

public abstract class CartItem(Product? product)
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    
    [Required (ErrorMessage = "Quantity is required")]
    public int Quantity { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime AddedAt { get; set; }

    // Navigation properties
    public Cart? Cart { get; set; }
    public Product? Product { get; set; } = product;
}