namespace IbgeAPI.DTOs.Requests.Ibge;

public class IbgeDTO
{
    public int Id { get; set; }
    public string State { get; set; } = null!;
    public string City { get; set; } = null!;

    public IbgeDTO() { }

    public IbgeDTO(int id)
    {
        Id = id;
    }

    public IbgeDTO(int id, string state, string city)
    {
        Id = Id;
        State = state;
        City = city;
    }

    public virtual Models.Ibge ToModel(IbgeDTO ibgeDTO)
    {
        return ToModelIbge(ibgeDTO);
    }

    public virtual IList<Models.Ibge> ToModelList(IList<IbgeDTO> ibgeDTOs)
    {
        return ToModelIbgeList(ibgeDTOs);
    }

    static Models.Ibge ToModelIbge(IbgeDTO ibgeDTO)
    {
        if (ibgeDTO is null)
            return new Models.Ibge();

        Models.Ibge _ibge = new();
        _ibge.Id = ibgeDTO.Id;
        _ibge.State = ibgeDTO.State;
        _ibge.City = ibgeDTO.City;
        return _ibge;
    }

    static IList<Models.Ibge> ToModelIbgeList(IList<IbgeDTO> ibgeDTOs)
    {
        List<Models.Ibge> _ibgeList = new();
        if (ibgeDTOs is not null)
        {
            foreach (var ibge in ibgeDTOs)
            {
                Models.Ibge _ibge = new();
                _ibge.Id = ibge.Id;
                _ibge.State = ibge.State;
                _ibge.City = ibge.City;
                _ibgeList.Add(_ibge);
            }
        }
        return _ibgeList;
    }
}
