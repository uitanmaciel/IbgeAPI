namespace IbgeAPI.Models.ValueObjects;

public class Password
{
    public string Keyword { get; private set; } = null!;

    public Password() { }

    public Password(string keyword)
    {
        Keyword = keyword;        
    }
}
