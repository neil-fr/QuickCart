namespace QuickCart.Application.DTOs;

public record ApiResponse<T>(
    bool Success,
    string? Message,
    T? Data = default
);