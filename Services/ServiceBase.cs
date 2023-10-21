namespace IbgeAPI.Services;

public class ServiceBase<T> : IServiceBase<T> where T : class
{
    private readonly IRepositoryBase<T> _repository;

    public ServiceBase(IRepositoryBase<T> repository)
    {
        _repository = repository;
    }

    public async Task<IResult> CreateAsync(T entity)
    {
        ApiResponse<T> _response = new();
        try
        {
            await _repository.CreateAsync(entity);
            return Results.Ok(_response.Message = "Successfully created.");
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }

    public async Task<IResult> DeleteAsync(T entity)
    {
        ApiResponse<T> _response = new();
        try
        {
            await _repository.DeleteAsync(entity);
            return Results.Ok(_response.Message = "Successfully deleted.");
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }

    public async Task<IResult> GetAllAsync(int? skip = 0, int? take = 25)
    {
        ApiResponse<IEnumerable<T>> _response = new();
        try
        {
            if (skip is null)
                skip = 0;
            if(take is null)
                take = 25;
            
            var _res = await _repository.GetAllAsync(Convert.ToInt32(skip), Convert.ToInt32(take));
            return Results.Ok(_response.Data = _res);
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }

    public async Task<IResult> GetByIdAsync(T entity)
    {
        ApiResponse<T> _response = new();
        try
        {
            var id = GetId(entity);
            return Results.Ok(_response.Data = await _repository.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }

    public async Task<IResult> UpdateAsync(T entity)
    {
        ApiResponse<T> _response = new();
        try
        {
            await _repository.UpdateAsync(entity);
            return Results.Ok(_response.Message = "Successfully updated.");
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }

    private dynamic GetId(T entity) 
    {
        dynamic id = 0;
        var props = entity.GetType().GetProperties();
        foreach (var prop in props)
        {
            if (prop.Name.Equals("Id"))
            {
                id = prop.GetValue(entity, null);
                break;
            }
        }
        return id;
    }
}
