using System.ComponentModel.DataAnnotations;

namespace QuickCart.Core.Entities;


public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int AddressId { get; set; }
    
    [Required (ErrorMessage = "Order date is required")]
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }
    
    [Required (ErrorMessage = "Total amount is required")]
    public decimal TotalAmount { get; set; }
    
    public string Status { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Address Address { get; set; }
    public ICollection<OrderItem> Items { get; set; }
}