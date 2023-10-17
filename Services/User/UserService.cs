using IbgeAPI.DTOs;

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
        var _result = new UserDTO().ToDTO(query);        
        return Results.Ok(_result);
    }   

    public async Task SingInAsync(Models.User user)
    {
        await _repository.CreateAsync(user);
    }

    public async Task<IResult> Login(Models.User user)
    {
        var result = new ApiResult<string>();
        try
        {
            var userDb = await _userRepository.GetByEmailAsync(user.Email.Address);
            if (userDb == null || !BCrypt.Net.BCrypt.Verify(user.Password.Keyword, userDb.Password.Keyword))
                throw new Exception("User Unauthorized. Invalid email or password.");

            var token = AuthenticationService.GenerateToken(user);
            result.Message = "Token generated";
            result.Data = token;
            return Results.Ok(result);
        }
        catch (Exception e)
        {            
            return Results.BadRequest(result.Error = e.Message);
        }
    }
}
