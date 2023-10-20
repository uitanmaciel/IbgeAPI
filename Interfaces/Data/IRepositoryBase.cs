namespace IbgeAPI.Interfaces.Data;

public interface IRepositoryBase<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(dynamic id);
    Task<IEnumerable<T>> GetAllAsync(int skip, int take);
}
