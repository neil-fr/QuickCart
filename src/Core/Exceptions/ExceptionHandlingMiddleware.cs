using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QuickCart.Application.DTOs;

namespace QuickCart.Core.Exceptions;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = exception switch
        {
            ApiException apiException => new ApiResponse<string>(false, apiException.Message, null),
            _ => new ApiResponse<string>(false, "An unexpected error occurred", null),
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception switch
        {
            ApiException apiException => apiException.StatusCode,
            _ => StatusCodes.Status500InternalServerError,
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        await context.Response.WriteAsJsonAsync(response, options);
    }
}
