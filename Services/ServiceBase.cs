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

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(T entity)
    {
        var id = GetId(entity);
        return await _repository.GetByIdAsync(id);
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
