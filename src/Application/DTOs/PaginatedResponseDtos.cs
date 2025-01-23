namespace QuickCart.Application.DTOs;

public record PaginatedResponseDto<T>(
    List<T> Items,
    int PageNumber,
    int PageSize,
    int TotalPages,
    int TotalCount
);