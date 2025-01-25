using QuickCart.Core.Entities;

namespace QuickCart.Core.Interfaces;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart?> GetByUserIdAsync(int userId);
    Task<Cart?> GetBySessionIdAsync(string sessionId);
    Task<bool> MergeCartsAsync(string sessionId, int userId);
    Task<bool> AddItemAsync(int cartId, int productId, int quantity);
    Task<bool> UpdateItemQuantityAsync(int cartId, int productId, int quantity);
    Task<bool> RemoveItemAsync(int cartId, int productId);
    Task ClearCartAsync(int cartId);
}