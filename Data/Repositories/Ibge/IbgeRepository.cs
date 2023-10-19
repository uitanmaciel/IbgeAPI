namespace IbgeAPI.Data.Repositories.Ibge;

public class IbgeRepository : RepositoryBase<Models.Ibge>, IIbgeRepository
{
    private readonly DataContext _context;

    public IbgeRepository(DataContext context) 
        : base(context)
    {
        _context = context;
    }

    public async Task<IList<Models.Ibge>> GetByCityAsync(string city)
    {
        var _cities = await _context.Ibge.AsNoTracking().Where(x => x.City.Contains(city)).ToListAsync();
        return _cities;
    }

    public async Task<Models.Ibge> GetByCodeAsync(int code)
    {
        return await _context.Ibge.AsNoTracking().SingleOrDefaultAsync(x => x.Id == code);
    }    

    public async Task<IList<Models.Ibge>> GetByStateAsync(string state)
    {
        var _states = await _context.Ibge.AsNoTracking().Where(x => x.State == state).ToListAsync();
        return _states;
    }

    public async Task<IList<Models.Ibge>> GetByStateAndCityAsync(string state, string city)
    {
        var _list = await _context.Ibge.AsNoTracking().Where(x => x.State == state && x.City.Contains(city)).ToListAsync();
        return _list;
    }

    public async Task<Models.Ibge> EditAsync(int id)
    {
        var entity = await _context.Ibge.FindAsync(id);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity; 
    }
}
