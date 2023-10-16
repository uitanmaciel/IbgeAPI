namespace IbgeAPI.Models;

public class Ibge
{
    public int Id { get; set; }
    public string State { get; set; } = null!;
    public string City { get; set; } = null!;

    public Ibge() { }

    public Ibge(int id)
    {
        Id = id;
    }
}