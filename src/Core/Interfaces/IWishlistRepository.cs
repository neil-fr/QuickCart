using QuickCart.Core.Entities;

namespace QuickCart.Core.Interfaces;

public interface IWishlistRepository
{
    Task<IEnumerable<WishlistItem>> GetUserWishlistAsync(int userId);
    Task<bool> AddItemAsync(int userId, int productId);
    Task<bool> RemoveItemAsync(int userId, int productId);
    Task<bool> IsProductInWishlistAsync(int userId, int productId);
}