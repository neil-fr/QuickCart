using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Constants;

namespace QuickCart.Core.Entities;

public class Category
{
    public int CategoryId { get; set; }
    
    [Required (ErrorMessage = "Category name is required")]
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Category name is too long")]
    public string Name { get; set; }
    
    [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "Category description is too long")]
    public string? Description { get; set; }
    
    public int? ParentCategoryId { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public Category? ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; }
    public ICollection<Product> Products { get; set; }
}