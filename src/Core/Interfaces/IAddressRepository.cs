using QuickCart.Core.Entities;

namespace QuickCart.Core.Interfaces;

public interface IAddressRepository : IRepository<Address>
{
    Task<IEnumerable<Address>> GetUserAddressesAsync(int userId);
    Task<bool> SetDefaultAddressAsync(int userId, int addressId);
    Task<Address?> GetUserDefaultAddressAsync(int userId);
}