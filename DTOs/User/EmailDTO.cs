using Flunt.Notifications;
using Flunt.Validations;

namespace IbgeAPI.DTOs.User;

public class EmailDTO : Notifiable<Notification>
{
    public string Address { get; set; } = null!;

    public EmailDTO() { }

    public EmailDTO(string address)
    {
        Address = address;
        ValidateFields(Address);
    }

    public virtual Models.ValueObjects.Email ToModel()
    {        
        return ToModelEmail();
    }

    public virtual EmailDTO ToDTO(Models.ValueObjects.Email email)
    {
        return ToDTOEmail(email);
    }

    private Models.ValueObjects.Email ToModelEmail()
    {        
        if (!IsValid)
            return new Models.ValueObjects.Email();

        Models.ValueObjects.Email _email = new Models.ValueObjects.Email(Address);       
        return _email;
    }

    static EmailDTO ToDTOEmail(Models.ValueObjects.Email email)
    {
        if (email is null)
            return new EmailDTO();

        EmailDTO _email = new();
        _email.Address = email.Address;
        return _email;
    }

    public void ValidateFields(string email)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(email, "Email", "Invalid email format."));
    }
}
