namespace IbgeAPI.Models.ValueObjects;

public class Email
{
    public string Address { get; set; } = null!;

    public Email() { }
    
    public Email(string address)
    {
        Address = address;        
    }    
}
