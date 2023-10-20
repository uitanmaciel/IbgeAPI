namespace IbgeAPI.DTOs.Responses.User;

public class GetedUserResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public GetedUserResponse() { }

    public virtual GetedUserResponse ToUserReponse(Models.User user)
    {
        return ToReponse(user);
    }

    static GetedUserResponse ToReponse(Models.User user)
    {
        if (user is null)
            return new GetedUserResponse();

        GetedUserResponse _userResponse = new();
        _userResponse.Id = user.Id;
        _userResponse.FirstName = user.FirstName;
        _userResponse.LastName = user.LastName;
        _userResponse.Email = user.Email.Address;
        return _userResponse;
    }
}
