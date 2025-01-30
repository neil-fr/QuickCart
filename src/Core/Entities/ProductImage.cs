using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;

namespace QuickCart.Core.Entities;

public class ProductImage
{
    public int ImageId { get; init; }
    public int ProductId { get; init; }

    [Required(ErrorMessage = "Image URL is required")]
    [ValidImageUrl]
    public string ImageUrl { get; init; } = null!;

    public bool IsMain { get; init; }

    // Navigation property
    public Product? Product { get; init; }
}
