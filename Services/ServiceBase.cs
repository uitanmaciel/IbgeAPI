using IbgeAPI.DTOs.Responses;

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
            return Results.Ok(_response.Message = "Usuário criado com sucesso.");
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
            return Results.Ok(_response.Message = "Usuário excluído com sucesso.");
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }

    public async Task<IResult> GetAllAsync(int skip = 0, int take = 25)
    {
        ApiResponse<IEnumerable<T>> _response = new();
        try
        {
            var _res = await _repository.GetAllAsync(skip, take);
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
            return Results.Ok(_response.Message = "Usuário atualizado com sucesso.");
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
