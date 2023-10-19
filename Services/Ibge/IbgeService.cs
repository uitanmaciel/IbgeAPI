using IbgeAPI.DTOs.Responses;
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

    public async Task<IResult> GetByCityAsync(string city)
    {
        ApiResponse<IList<IbgeResponse>> _responseList = new();
        try
        {
            var _dto = new IbgeResponse().ToResponseList(await _ibgeRepository.GetByCityAsync(city));
            return Results.Ok(_responseList.Data = _dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IResult> GetByCodeAsync(int code)
    {
        ApiResponse<IbgeResponse> _response = new();
        try
        {
            var dto = await _ibgeRepository.GetByCodeAsync(code);
            var ttt = new IbgeResponse().ToReponse(dto);
            return Results.Ok(_response.Data = ttt);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }    

    public async Task<IResult> GetByStateAsync(string state)
    {
        ApiResponse<IList<IbgeResponse>> _response = new();
        try
        {
            var dto = await _ibgeRepository.GetByStateAsync(state);
            var ttt = new IbgeResponse().ToResponseList(dto);
            return Results.Ok(_response.Data = ttt);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IResult> GetByStateAndCityAsync(string state, string city)
    {
        ApiResponse<IList<IbgeResponse>> _response = new();
        try
        {
            var dto = await _ibgeRepository.GetByStateAndCityAsync(state, city);
            var ttt = new IbgeResponse().ToResponseList(dto);
            return Results.Ok(_response.Data = ttt);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IResult> EditAsync(Models.Ibge model)
    {
        ApiResponse<IbgeResponse> _response = new();
        try
        {
            await _ibgeRepository.EditAsync(model.Id);
            return Results.Ok(_response.Message = "Registro atualizado com sucesso.");
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }
}
