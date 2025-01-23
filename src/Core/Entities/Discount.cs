using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;

namespace QuickCart.Core.Entities;

public class Discount
{
    public int DiscountId { get; set; }
    public int ProductId { get; set; }
    
    [Required (ErrorMessage = "Discount percentage is required")]
    [DiscountValidation]
    public decimal DiscountPercentage { get; set; }
    
    [Required (ErrorMessage = "Start date is required")]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }
    
    [Required (ErrorMessage = "End date is required")]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
    
    public bool IsActive { get; set; }

    // Navigation property
    public Product Product { get; set; }
}