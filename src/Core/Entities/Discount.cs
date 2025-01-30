using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;

namespace QuickCart.Core.Entities;

public class Discount
{
    public int DiscountId { get; init; }
    public int ProductId { get; init; }

    [Required(ErrorMessage = "Discount percentage is required")]
    [DiscountValidation]
    public decimal DiscountPercentage { get; init; }

    [Required(ErrorMessage = "Start date is required")]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; init; }

    [Required(ErrorMessage = "End date is required")]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; init; }

    public bool IsActive { get; init; }

    // Navigation property
    public Product? Product { get; init; }
}
