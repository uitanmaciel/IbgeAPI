

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
        ApiResponse<GetedUserResponse> _response = new();
        try
        {
            var query = await _userRepository.GetByEmailAsync(email);
            var _result = new GetedUserResponse().ToUserReponse(query);
            return Results.Ok(_response.Data = _result);
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }   

    public async Task<IResult> SingInAsync(Models.User user)
    {
        ApiResponse<CreatedUserResponse> _response = new();
        try
        {
            await _repository.CreateAsync(user);
            return Results.Ok(_response.Message = "User created successfully.");
        }
        catch (Exception e)
        {
            return Results.BadRequest(_response.Error = e.Message);
        }
    }

    public async Task<IResult> Login(Models.User user)
    {
        var auth = new AuthorizedResponse();
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
