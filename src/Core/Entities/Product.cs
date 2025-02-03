using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Core.Entities;

public class Product
{
    public int ProductId { get; init; }

    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(ValidationConstants.MaxNameLength,
        ErrorMessage = "Product Name is too long")]
    public string Name { get; init; } = null!;

    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(
        ValidationConstants.MaxNameLength,
        ErrorMessage = "Product Description is too long"
    )]
    public string Description { get; init; } = null!;

    [Required(ErrorMessage = "Product Price is required")]
    [PriceRange]
    public decimal Price { get; init; }

    [Required(ErrorMessage = "Please enter total stock of this product")]
    [StockValidation]
    public int TotalStock { get; init; }
    [DataType(DataType.DateTime)] public DateTime CreatedAt { get; init; }
}
