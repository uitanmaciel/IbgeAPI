namespace IbgeAPI.Data.Repositories.User;

public class UserRepository : RepositoryBase<Models.User>, IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context) 
        : base(context)
    {
        _context = context;
    }

    public async Task<Models.User> GetByEmailAsync(string email)
    {
        return await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Email.Address == email);
    }    
}
