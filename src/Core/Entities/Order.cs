using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Entities;


public abstract class Order(
    int orderId = 0,
    int userId = 0,
    int addressId = 0,
    DateTime orderDate = default,
    decimal totalAmount = 0,
    string? status = null,
    User? user = null,
    Address? address = null,
    ICollection<OrderItem>? items = null)
{
    public int OrderId { get; set; } = orderId;
    public int UserId { get; set; } = userId;
    public int AddressId { get; set; } = addressId;

    [Required (ErrorMessage = "Order date is required")]
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; } = orderDate;

    [Required (ErrorMessage = "Total amount is required")]
    public decimal TotalAmount { get; set; } = totalAmount;

    public string Status { get; set; } = status ?? throw new ArgumentNullException(nameof(status));

    // Navigation properties
    public User User { get; set; } = user ?? throw new ArgumentNullException(nameof(user));
    public Address Address { get; set; } = address ?? throw new ArgumentNullException(nameof(address));
    public ICollection<OrderItem> Items { get; set; } = items ?? throw new ArgumentNullException(nameof(items));
}