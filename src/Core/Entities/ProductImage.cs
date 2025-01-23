using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Attributes;

namespace QuickCart.Core.Entities;

public class ProductImage
{
    public int ImageId { get; set; }
    public int ProductId { get; set; }
    
    [Required (ErrorMessage = "Image URL is required")]
    [ValidImageUrl]
    public string ImageUrl { get; set; }
    
    public bool IsMain { get; set; }

    // Navigation property
    public Product Product { get; set; }
}