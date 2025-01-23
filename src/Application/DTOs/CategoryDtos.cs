using System.ComponentModel.DataAnnotations;
using QuickCart.Core.Constants;

namespace QuickCart.Application.DTOs;

public record CategoryCreateDto(

    [Required(ErrorMessage = "Category name is required")]
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Category name must be between 2 and 100 characters")]
    string Name,
    
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Category description must be between 4 and 100 characters")]
    string? Description,
    
    int? ParentCategoryId
);


public record CategoryResponseDto(
    int CategoryId,
    
    [Required(ErrorMessage = "Category name is required")]
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Category name must be between 2 and 100 characters")]
    string Name,
    
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Category description must be between 4 and 100 characters")]
    string? Description,
    
    int? ParentCategoryId,
    
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Parent Category name must be between 4 and 100 characters")]
    string? ParentCategoryName,
    bool IsActive,
    
    List<CategoryResponseDto> SubCategories
);

public record CategoryUpdateDto(
    [Required(ErrorMessage = "Category name is required")]
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Category name must be between 2 and 100 characters")]
    string Name,
    
    [StringLength(ValidationConstants.MaxNameLength, MinimumLength = 4,
        ErrorMessage = "Category description must be between 4 and 100 characters")]
    string? Description,
    
    bool IsActive
);