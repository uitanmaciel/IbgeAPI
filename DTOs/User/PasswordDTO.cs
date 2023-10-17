using Flunt.Notifications;
using Flunt.Validations;
using static BCrypt.Net.BCrypt;

namespace IbgeAPI.DTOs.User;

public class PasswordDTO : Notifiable<Notification>
{
    public string Password { get; set; } = null!;

    public PasswordDTO() { }

    public PasswordDTO(string password)
    {
        Password = password;
        //ValidateFields(Password);
    }

    public virtual Models.ValueObjects.Password ToModel()
    {
        return ToModelPassword();
    }

    public virtual PasswordDTO ToDTO(Models.ValueObjects.Password password)
    {
        return ToDTOPassword(password);
    }

    Models.ValueObjects.Password ToModelPassword()
    {
        if (Password is null)
            return new Models.ValueObjects.Password();

        Models.ValueObjects.Password _password = new Models.ValueObjects.Password(HashPassword(Password));        
        return _password;
    }

    static PasswordDTO ToDTOPassword(Models.ValueObjects.Password password)
    {
        if (password is null)
            return new PasswordDTO();

        PasswordDTO _password = new();
        _password.Password = password.Keyword;
        return _password;
    }

    void ValidateFields(string password)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNullOrEmpty(password, "Password", "Password is required."));
    }
}
