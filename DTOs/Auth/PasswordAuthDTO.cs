namespace IbgeAPI.DTOs.Auth;

public class PasswordAuthDTO
{
    public string Password { get; set; } = null!;

    public PasswordAuthDTO() { }

    public PasswordAuthDTO(string password)
    {
        Password = password;
    }

    public virtual Models.ValueObjects.Password ToModel(PasswordAuthDTO passwordDTO)
    {
        return ToModelPassword(passwordDTO);
    }

    static Models.ValueObjects.Password ToModelPassword(PasswordAuthDTO passwordDTO)
    {
        if(passwordDTO is null)
            return new Models.ValueObjects.Password();

        Models.ValueObjects.Password _password = new();
        _password.Keyword = passwordDTO.Password;
        return _password;
    }
}
