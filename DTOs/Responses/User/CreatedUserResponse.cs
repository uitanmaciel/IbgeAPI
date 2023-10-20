namespace IbgeAPI.DTOs.Responses.User;

public class CreatedUserResponse
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public CreatedUserResponse() { }

    public virtual CreatedUserResponse ToUserReponse(Models.User user)
    {
        return ToReponse(user);
    }

    static CreatedUserResponse ToReponse(Models.User user)
    {
        if (user is null)
            return new CreatedUserResponse();

        CreatedUserResponse _userResponse = new();
        _userResponse.FirstName = user.FirstName;
        _userResponse.LastName = user.LastName;
        _userResponse.Email = user.Email.Address;
        return _userResponse;
    }
}
