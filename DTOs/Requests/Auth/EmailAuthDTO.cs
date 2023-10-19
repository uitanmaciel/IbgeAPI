namespace IbgeAPI.DTOs.Requests.Auth;

public class EmailAuthDTO
{
    public string Address { get; set; } = null!;

    public EmailAuthDTO() { }

    public EmailAuthDTO(string address)
    {
        Address = address;
    }

    public virtual Email ToModel(EmailAuthDTO emailDTO)
    {
        return ToModelEmail(emailDTO);
    }

    static Email ToModelEmail(EmailAuthDTO emailDTO)
    {
        if (emailDTO is null)
            return new Email();

        Email _emailAuth = new Email(emailDTO.Address);
        return _emailAuth;
    }
}
