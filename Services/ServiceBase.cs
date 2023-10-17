using IbgeAPI.DTOs;

namespace IbgeAPI.Services;

public class ServiceBase<T> : IServiceBase<T> where T : class
{
    private readonly IRepositoryBase<T> _repository;

    public ServiceBase(IRepositoryBase<T> repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(T entity)
    {
        await _repository.CreateAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {        
        await _repository.DeleteAsync(entity);
    }

    public async Task<IResult> GetAllAsync()
    {
        try
        {
            var _result = await _repository.GetAllAsync();
            return Results.Ok(_result);
        }
        catch (Exception e)
        {
            var _result = new ApiResult<string>() { Error = e.Message };
            return Results.BadRequest(_result);
        }
    }

    public async Task<IResult> GetByIdAsync(T entity)
    {
        try
        {
            var id = GetId(entity);
            var _result = await _repository.GetByIdAsync(id);
            return Results.Ok(_result);
        }
        catch (Exception e)
        {
            var _result = new ApiResult<string>() { Error = e.Message };
            return Results.BadRequest(_result);
        }
    }

    public async Task UpdateAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
    }

    private dynamic GetId(T entity) 
    {
        dynamic id = 0;
        var props = entity.GetType().GetProperties();
        foreach (var prop in props)
        {
            if (prop.Name.Equals("Id") && prop.GetType() == typeof(System.Guid))
            {
                id = (Guid)prop.GetValue(entity, null);
                break;
            }
            
            if(prop.Name.Equals("Id") && prop.GetType() == typeof(System.Int32))
            {
                id = (int)prop.GetValue(entity, null);
                break;
            }
        }
        return id;
    }
}
