namespace IbgeAPI.Interfaces.Services;

public interface IServiceBase<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IResult> GetByIdAsync(T entity);
    Task<IResult> GetAllAsync();
}
