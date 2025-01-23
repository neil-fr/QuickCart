using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;
using QuickCart.Core.Constants;

namespace QuickCart.Core.Entities;

public class Product
{
    public int ProductId { get; set; }
    
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Name is too long")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Product Description is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Product Description is too long")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Product Price is required")]
    [PriceRange]
    public decimal Price { get; set; }
    
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage = "Please enter total stock of this product")]
    [StockValidation]
    public int TotalStock { get; set; }
    
    [StockValidation]
    public int RemainingStock { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime? UpdatedAt { get; set; }
    
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public Category Category { get; set; }
    public ICollection<ProductImage> Images { get; set; }
    public ICollection<Discount> Discounts { get; set; }
}