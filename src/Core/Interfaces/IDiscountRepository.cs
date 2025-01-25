using QuickCart.Core.Entities;

namespace QuickCart.Core.Interfaces;

public interface IDiscountRepository : IRepository<Discount>
{
    Task<IEnumerable<Discount>> GetActiveDiscountsAsync();
    Task<Discount?> GetProductActiveDiscountAsync(int productId);
    Task<bool> HasOverlappingDiscountAsync(int productId, DateTime startDate, DateTime endDate);
    Task<bool> DeactivateExpiredDiscountsAsync();
}