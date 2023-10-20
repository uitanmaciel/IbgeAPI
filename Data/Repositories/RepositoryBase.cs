namespace IbgeAPI.Data.Repositories;

public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(DataContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }    

    public async Task<IEnumerable<T>> GetAllAsync(int skip, int take)
    {

        return await _dbSet.AsNoTracking().Skip(skip).Take(take).ToListAsync();
    }

    public async Task<T> GetByIdAsync(dynamic id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
