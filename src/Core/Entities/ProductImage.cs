using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;

namespace QuickCart.Core.Entities;

public class ProductImage(
    int imageId = 0,
    int productId = 0,
    string? imageUrl = null,
    bool isMain = false,
    Product? product = null)
{
    public int ImageId { get; init; } = imageId;
    public int ProductId { get; init; } = productId;

    [Required (ErrorMessage = "Image URL is required")]
    [ValidImageUrl]
    public string ImageUrl { get; init; } = imageUrl ??
                                            throw new ArgumentNullException(nameof(imageUrl));

    public bool IsMain { get; init; } = isMain;

    // Navigation property
    public Product Product { get; init; } = product ?? throw new ArgumentNullException(nameof(product));
}