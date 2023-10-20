namespace IbgeAPI.Interfaces.Services;

public interface IServiceBase<T> where T : class
{
    Task<IResult> CreateAsync(T entity);
    Task<IResult> UpdateAsync(T entity);
    Task<IResult> DeleteAsync(T entity);
    Task<IResult> GetByIdAsync(T entity);
    Task<IResult> GetAllAsync(int? skip, int? take);
}
