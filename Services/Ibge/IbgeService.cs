using IbgeAPI.DTOs.Responses.Ibge;

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

    public async Task<IList<IbgeResponse>> GetByCityAsync(string city)
    {
        var _response = await _ibgeRepository.GetByCityAsync(city);
        return new IbgeResponse().ToResponseList(_response);
    }

    public async Task<IbgeResponse> GetByCodeAsync(int code)
    {
        var _response = await _ibgeRepository.GetByCodeAsync(code);
        return new IbgeResponse().ToReponse(_response);
    }    

    public async Task<IList<IbgeResponse>> GetByStateAsync(string state)
    {
        var _response = await _ibgeRepository.GetByStateAsync(state);
        return new IbgeResponse().ToResponseList(_response);
    }

    public async Task<IList<IbgeResponse>> GetByStateAndCityAsync(string state, string city)
    {
        var _response = await _ibgeRepository.GetByStateAndCityAsync(state, city);
        return new IbgeResponse().ToResponseList(_response);
    }

    public async Task<IbgeResponse> EditAsync(Models.Ibge model)
    {
        var _response = await _ibgeRepository.EditAsync(model.Id);
        return new IbgeResponse().ToReponse(_response);
    }
}
