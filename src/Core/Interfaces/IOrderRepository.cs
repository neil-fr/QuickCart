using QuickCart.Application.DTOs;
using QuickCart.Core.Entities;

namespace QuickCart.Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
        Task<Order?> GetOrderWithDetailsAsync(int orderId);
        Task<bool> UpdateOrderStatusAsync(int orderId, string status);
        Task<PaginatedResponseDto<Order>> GetPaginatedAsync(int pageNumber, int pageSize);
    }
}
