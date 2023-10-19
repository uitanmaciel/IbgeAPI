using IbgeAPI.DTOs.Responses.Ibge;

namespace IbgeAPI.Interfaces.Services.Ibge;

public interface IIbgeService : IServiceBase<Models.Ibge>
{
    Task<IbgeResponse> EditAsync(Models.Ibge model);
    Task<IbgeResponse> GetByCodeAsync(int code);
    Task<IList<IbgeResponse>> GetByCityAsync(string city);
    Task<IList<IbgeResponse>> GetByStateAsync(string state);
    Task<IList<IbgeResponse>> GetByStateAndCityAsync(string state, string city);
}
