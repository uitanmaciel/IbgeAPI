namespace IbgeAPI.DTOs.Requests.User;

public class CreateUserDTO
{
    private Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public EmailDTO Email { get; set; } = null!;
    public PasswordDTO Password { get; set; } = null!;

    public CreateUserDTO() { }

    public CreateUserDTO(Guid id)
    {
        Id = id;
    }

    public CreateUserDTO(Guid id, string? firstName, string? lastName, EmailDTO email, PasswordDTO password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public virtual Models.User ToModel(CreateUserDTO user)
    {
        return ToModelUser(user);
    }

    public virtual IList<Models.User> ToModelList(IList<CreateUserDTO> users)
    {
        return ToModelUserList(users);
    }

    static Models.User ToModelUser(CreateUserDTO userDTO)
    {
        if (userDTO is null)
            return new Models.User();

        Models.User _user = new();
        _user.Id = Guid.NewGuid();
        _user.FirstName = userDTO.FirstName;
        _user.LastName = userDTO.LastName;
        _user.Email = new EmailDTO(userDTO.Email.Address).ToModel();
        _user.Password = new PasswordDTO(userDTO.Password.Password).ToModel();
        return _user;
    }

    static IList<Models.User> ToModelUserList(IList<CreateUserDTO> users)
    {
        List<Models.User> _usersList = new();
        if (users is not null)
        {
            foreach (var user in users)
            {
                Models.User _user = new();
                _user.Id = user.Id;
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.Email = new EmailDTO(user.Email.Address).ToModel();
                _usersList.Add(_user);
            }
        }
        return _usersList;
    }
}
