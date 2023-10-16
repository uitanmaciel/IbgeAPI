namespace IbgeAPI.Models;

public class User
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Email Email { get; set; } = null!;
    public Password Password { get; set; } = null!;

    public User() { }

    public User(Guid id)
    {
        Id = id;
    }
}
