namespace IbgeAPI.DTOs.Auth;

public class EmailAuthDTO
{
    public string Address { get; set; } = null!;

    public EmailAuthDTO() { }

    public EmailAuthDTO(string address)
    {
        Address = address;        
    }

    public virtual Models.ValueObjects.Email ToModel(EmailAuthDTO emailDTO)
    {
        return ToModelEmail(emailDTO);
    }

    static Models.ValueObjects.Email ToModelEmail(EmailAuthDTO emailDTO)
    {
        if(emailDTO is null)
            return new Models.ValueObjects.Email();

        Models.ValueObjects.Email _emailAuth = new();
        _emailAuth.Address = emailDTO.Address;
        return _emailAuth;
    }
}
