using IbgeAPI.Services.Authentication;

namespace IbgeAPI.Services.User;

public class UserService : ServiceBase<Models.User>, IUserService
{
    private readonly IRepositoryBase<Models.User> _repository;
    private readonly IUserRepository _userRepository;
    public UserService(IRepositoryBase<Models.User> repository, IUserRepository userRepository) 
        : base(repository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<Models.User> GetByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }   

    public async Task SingInAsync(Models.User user)
    {
        await _repository.CreateAsync(user);
    }

    public async Task<IResult> Login(Models.User user)
    {
        try
        {
            var userDb = await _userRepository.GetByEmailAsync(user.Email.Address);
            if (userDb == null || !BCrypt.Net.BCrypt.Verify(user.Password.Keyword, userDb.Password.Keyword))
                throw new Exception("User Unauthorized. Invalid email or password.");

            var token = AuthenticationService.GenerateToken(user);
            return Results.Ok(token);
        }
        catch (System.Exception)
        {            
            return Results.BadRequest();
        }
    }
}
