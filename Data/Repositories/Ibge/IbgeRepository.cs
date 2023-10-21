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
        return await _context.Ibge.AsNoTracking().Where(x => x.City.Contains(city)).ToListAsync();
    }

    public async Task<Models.Ibge> GetByCodeAsync(int code)
    {
        return await _context.Ibge.AsNoTracking().SingleOrDefaultAsync(x => x.Id == code);
    }

    public async Task<IList<Models.Ibge>> GetByStateAsync(string state, int skip, int take)
    {
        return await _context.Ibge.AsNoTracking()
                                  .Where(x => x.State == state)
                                  .Skip(skip)
                                  .Take(take).ToListAsync();
}

    public async Task<IList<Models.Ibge>> GetByStateAndCityAsync(string state, string city)
    {
        return await _context.Ibge.AsNoTracking()
            .Where(x => x.State == state && x.City.Contains(city)).ToListAsync();
    }

    public async Task EditAsync(int id)
    {
        var entity = await _context.Ibge.FindAsync(id);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
