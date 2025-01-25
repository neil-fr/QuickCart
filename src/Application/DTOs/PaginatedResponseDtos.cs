namespace QuickCart.Application.DTOs;

public abstract record PaginatedResponseDto<T>(
    List<T> Items,
    int PageNumber,
    int PageSize,
    int TotalPages,
    int TotalCount
);