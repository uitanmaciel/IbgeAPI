namespace IbgeAPI.Interfaces.Data.User;

public interface IUserRepository
{        
    Task<Models.User> GetByEmailAsync(string email);
}
