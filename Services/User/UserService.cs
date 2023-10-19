using IbgeAPI.DTOs.Responses.User;

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

    public async Task<IResult> GetByEmailAsync(string email)
    {
        var query = await _userRepository.GetByEmailAsync(email);
        var _result = new UserResponse().ToUserReponse(query);        
        return Results.Ok(_result);
    }   

    public async Task SingInAsync(Models.User user)
    {
        await _repository.CreateAsync(user);
    }

    public async Task<IResult> Login(Models.User user)
    {
        var auth = new AuthReponse();
        try
        {
            var userDb = await _userRepository.GetByEmailAsync(user.Email.Address);
            if (userDb == null || !BCrypt.Net.BCrypt.Verify(user.Password.Keyword, userDb.Password.Keyword))
                throw new Exception("User Unauthorized. Invalid email or password.");

            var token = AuthenticationService.GenerateToken(user);
            auth.Message = "Token generated";
            auth.Data = token;
            return Results.Ok(auth);
        }
        catch (Exception e)
        {            
            return Results.BadRequest(auth.Error = e.Message);
        }
    }
}
