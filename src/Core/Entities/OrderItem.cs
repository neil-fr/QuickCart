using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;

namespace QuickCart.Core.Entities;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    
    [Required (ErrorMessage = "Quantity is required")]
    [MinLength(1, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }
    
    [Required (ErrorMessage = "Price at time is required")]
    [PriceRange]
    public decimal PriceAtTime { get; set; }
    
    [DiscountValidation]
    public decimal? DiscountAtTime { get; set; }

    // Navigation properties
    public Order Order { get; set; }
    public Product Product { get; set; }
}