namespace IbgeAPI.Interfaces.Services.Ibge;

public interface IIbgeService : IServiceBase<Models.Ibge>
{
    Task<IResult> EditAsync(Models.Ibge model);
    Task<Models.Ibge> GetByCodeAsync(int code);
    Task<IList<Models.Ibge>> GetByCityAsync(string city);
    Task<IList<Models.Ibge>> GetByStateAsync(string state);
    Task<IList<Models.Ibge>> GetByStateAndCityAsync(string state, string city);
}
