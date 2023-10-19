using Flunt.Notifications;
using Flunt.Validations;
using static BCrypt.Net.BCrypt;

namespace IbgeAPI.DTOs.Requests.User;

public class PasswordDTO : Notifiable<Notification>
{
    public string Password { get; set; } = null!;

    public PasswordDTO() { }

    public PasswordDTO(string password)
    {
        Password = password;
        //ValidateFields(Password);
    }

    public virtual Password ToModel()
    {
        return ToModelPassword();
    }

    Password ToModelPassword()
    {
        if (Password is null)
            return new Password();

        Password _password = new Password(HashPassword(Password));
        return _password;
    }

    void ValidateFields(string password)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNullOrEmpty(password, "Password", "Password is required."));
    }
}
