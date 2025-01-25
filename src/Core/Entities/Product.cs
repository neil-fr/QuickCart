using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Core.Entities;

public class Product(
    int productId = 0,
    string? name = null,
    string? description = null,
    decimal price = 0,
    int categoryId = 0,
    int totalStock = 0,
    int remainingStock = 0,
    DateTime createdAt = default,
    DateTime? updatedAt = null,
    bool isActive = false,
    Category? category = null,
    ICollection<ProductImage>? images = null,
    ICollection<Discount>? discounts = null)
{
    public int ProductId { get; init; } = productId;

    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Name is too long")]
    public string Name { get; init; } = name ?? throw new ArgumentNullException(nameof(name));

    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Description is too long")]
    public string Description { get; init; } = description ??
                                               throw new ArgumentNullException(nameof(description));

    [Required(ErrorMessage = "Product Price is required")]
    [PriceRange]
    public decimal Price { get; init; } = price;

    public int CategoryId { get; init; } = categoryId;

    [Required(ErrorMessage = "Please enter total stock of this product")]
    [StockValidation]
    public int TotalStock { get; init; } = totalStock;

    [StockValidation]
    public int RemainingStock { get; init; } = remainingStock;

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; init; } = createdAt;

    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; init; } = updatedAt;

    public bool IsActive { get; init; } = isActive;

    // Navigation properties
    public Category Category { get; init; } = category ??
                                              throw new ArgumentNullException(nameof(category));

    public ICollection<ProductImage> Images { get; set; } = images ?? throw new ArgumentNullException(nameof(images));
    public ICollection<Discount> Discounts { get; set; } = discounts ??
                                                           throw new ArgumentNullException(nameof(discounts));
}