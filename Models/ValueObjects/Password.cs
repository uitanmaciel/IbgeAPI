namespace IbgeAPI.Models.ValueObjects;

public class Password
{
    public string Keyword { get; set; } = null!;

    public Password() { }

    public Password(string keyword)
    {
        Keyword = keyword;        
    }
}
