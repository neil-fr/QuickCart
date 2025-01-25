using QuickCart.Core.Entities;

namespace QuickCart.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);
        Task UpdateLastLoginAsync(int userId);
        Task<bool> UpdatePasswordAsync(int userId, string passwordHash);
    }
}
