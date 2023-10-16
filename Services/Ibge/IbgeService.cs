namespace IbgeAPI.Services.Ibge;

public class IbgeService : ServiceBase<Models.Ibge>, IIbgeService
{
    private readonly IRepositoryBase<Models.Ibge> _repository;
    private readonly IIbgeRepository _ibgeRepository;

    public IbgeService(IRepositoryBase<Models.Ibge> repository, IIbgeRepository ibgeRepository) 
        : base(repository)
    {
        _repository = repository;
        _ibgeRepository = ibgeRepository;
    }

    public async Task<IList<Models.Ibge>> GetByCityAsync(string city)
    {
        return await _ibgeRepository.GetByCityAsync(city);
    }

    public async Task<Models.Ibge> GetByCodeAsync(int code)
    {
        return await _ibgeRepository.GetByCodeAsync(code);
    }    

    public async Task<IList<Models.Ibge>> GetByStateAsync(string state)
    {
        return await _ibgeRepository.GetByStateAsync(state);
    }

    public async Task<IList<Models.Ibge>> GetByStateAndCityAsync(string state, string city)
    {
        return await _ibgeRepository.GetByStateAndCityAsync(state, city);
    }
}
