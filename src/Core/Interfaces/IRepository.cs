namespace QuickCart.Core.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}