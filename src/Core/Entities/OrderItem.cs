using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;

namespace QuickCart.Core.Entities;

public abstract class OrderItem(
    int orderItemId = 0,
    int orderId = 0,
    int productId = 0,
    int quantity = 0,
    decimal priceAtTime = 0,
    decimal? discountAtTime = null,
    Order? order = null,
    Product? product = null)
{
    public int OrderItemId { get; set; } = orderItemId;
    public int OrderId { get; set; } = orderId;
    public int ProductId { get; set; } = productId;

    [Required (ErrorMessage = "Quantity is required")]
    [MinLength(1, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; } = quantity;

    [Required (ErrorMessage = "Price at time is required")]
    [PriceRange]
    public decimal PriceAtTime { get; set; } = priceAtTime;

    [DiscountValidation]
    public decimal? DiscountAtTime { get; set; } = discountAtTime;

    // Navigation properties
    public Order Order { get; set; } = order ?? throw new ArgumentNullException(nameof(order));
    public Product Product { get; set; } = product ?? throw new ArgumentNullException(nameof(product));
}