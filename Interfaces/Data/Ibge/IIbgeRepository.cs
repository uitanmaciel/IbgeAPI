namespace IbgeAPI.Interfaces.Data.Ibge;

public interface IIbgeRepository
{
    Task EditAsync(int id);
    Task<Models.Ibge> GetByCodeAsync(int code);
    Task<IList<Models.Ibge>> GetByCityAsync(string city);
    Task<IList<Models.Ibge>> GetByStateAsync(string state);
    Task<IList<Models.Ibge>> GetByStateAndCityAsync(string state, string city);
}
