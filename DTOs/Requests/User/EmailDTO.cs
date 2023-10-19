using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeAPI.DTOs.Requests.User;

public class EmailDTO : Notifiable<Notification>
{
    public string Address { get; set; } = null!;

    public EmailDTO() { }

    public EmailDTO(string address)
    {
        Address = address;
        ValidateFields(Address);
    }

    public virtual Email ToModel()
    {
        return ToModelEmail();
    }

    private Email ToModelEmail()
    {
        if (!IsValid)
            return new Email();

        Email _email = new Email(Address);
        return _email;
    }

    public void ValidateFields(string email)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(email, "Email", "Invalid email format."));
    }
}
