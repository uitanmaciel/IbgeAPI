namespace IbgeAPI.DTOs.Requests.Auth;

public class AuthDTO
{
    public EmailAuthDTO Email { get; set; } = null!;
    public PasswordAuthDTO Password { get; set; } = null!;

    public AuthDTO() { }

    public AuthDTO(EmailAuthDTO email, PasswordAuthDTO password)
    {
        Email = email;
        Password = password;
    }

    public virtual Models.User ToModel(AuthDTO userDTO)
    {
        return ToModelUser(userDTO);
    }

    static Models.User ToModelUser(AuthDTO user)
    {
        if (user is null)
            return new Models.User();

        Models.User _user = new();
        _user.Email = new EmailAuthDTO().ToModel(user.Email);
        _user.Password = new PasswordAuthDTO().ToModel(user.Password);
        return _user;
    }
}
