namespace IbgeAPI.DTOs.Responses.Ibge;

public class IbgeResponse
{
    public int Id { get; set; }
    public string State { get; set; } = null!;
    public string City { get; set; } = null!;

    public IbgeResponse() { }

    public virtual IbgeResponse ToReponse(Models.Ibge ibge)
    {
        return ToIbgeResponse(ibge);
    }

    public virtual IList<IbgeResponse> ToResponseList(IList<Models.Ibge> ibges)
    {
        return ToIbgeReponseList(ibges);
    }

    static IbgeResponse ToIbgeResponse(Models.Ibge ibge)
    {
        if(ibge is null)
            return new IbgeResponse();

        IbgeResponse _ibgeResponse = new();
        _ibgeResponse.Id = ibge.Id;
        _ibgeResponse.State = ibge.State;
        _ibgeResponse.City = ibge.City;
        return _ibgeResponse;
    }

    static IList<IbgeResponse> ToIbgeReponseList(IList<Models.Ibge> ibges)
    {
        List<IbgeResponse> _ibgeResponseList = new();
        if (ibges is not null)
        {
            foreach (var ibge in ibges)
            {
                IbgeResponse _ibgeResponse = new();
                _ibgeResponse.Id = ibge.Id;
                _ibgeResponse.State = ibge.State;
                _ibgeResponse.City = ibge.City;
                _ibgeResponseList.Add(_ibgeResponse);
            }
        }
        return _ibgeResponseList;
    }
}