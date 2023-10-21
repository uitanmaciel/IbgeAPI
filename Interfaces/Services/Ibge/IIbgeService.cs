using IbgeAPI.DTOs.Responses.Ibge;

namespace IbgeAPI.Interfaces.Services.Ibge;

public interface IIbgeService : IServiceBase<Models.Ibge>
{
    Task<IResult> EditAsync(Models.Ibge model);
    Task<IResult> GetByCodeAsync(int code);
    Task<IResult> GetByCityAsync(string city);
    Task<IResult> GetByStateAsync(string state, int? skip, int? take);
    Task<IResult> GetByStateAndCityAsync(string state, string city);
}
