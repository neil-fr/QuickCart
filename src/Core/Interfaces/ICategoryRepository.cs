using QuickCart.Core.Entities;

namespace QuickCart.Core.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithSubcategoriesAsync();
        Task<Category?> GetWithProductsAsync(int categoryId);
        Task<bool> HasProductsAsync(int categoryId);
        Task<IEnumerable<Category>> GetMainCategoriesAsync();
    }
}
