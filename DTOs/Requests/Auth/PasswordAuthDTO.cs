namespace IbgeAPI.DTOs.Requests.Auth;

public class PasswordAuthDTO
{
    public string Password { get; set; } = null!;

    public PasswordAuthDTO() { }

    public PasswordAuthDTO(string password)
    {
        Password = password;
    }

    public virtual Password ToModel(PasswordAuthDTO passwordDTO)
    {
        return ToModelPassword(passwordDTO);
    }

    static Password ToModelPassword(PasswordAuthDTO passwordDTO)
    {
        if (passwordDTO is null)
            return new Password();

        Password _password = new Password(passwordDTO.Password);
        return _password;
    }
}
