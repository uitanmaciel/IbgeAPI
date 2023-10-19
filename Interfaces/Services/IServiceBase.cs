namespace IbgeAPI.Interfaces.Services;

public interface IServiceBase<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
}
