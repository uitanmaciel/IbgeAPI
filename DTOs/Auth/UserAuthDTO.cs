namespace IbgeAPI.DTOs.Auth;

public class UserAuthDTO
{
    public EmailAuthDTO Email { get; set; } = null!;
    public PasswordAuthDTO Password { get; set; } = null!;

    public UserAuthDTO() { }

    public UserAuthDTO(EmailAuthDTO email, PasswordAuthDTO password)
    {
        Email = email;
        Password = password;
    }

    public virtual Models.User ToModel(UserAuthDTO userDTO)
    {
        return ToModelUser(userDTO);
    }

    static Models.User ToModelUser(UserAuthDTO user)
    {
        if(user is null)
            return new Models.User();

        Models.User _user = new();
        _user.Email = new EmailAuthDTO().ToModel(user.Email);
        _user.Password = new PasswordAuthDTO().ToModel(user.Password);
        return _user;
    }
}
