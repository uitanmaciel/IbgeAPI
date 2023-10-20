namespace IbgeAPI.DTOs.Requests.User;

public class UpdateUserDTO
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public EmailDTO Email { get; set; } = null!;

    public UpdateUserDTO() { }

    public UpdateUserDTO(Guid id)
    {
        Id = id;
    }

    public UpdateUserDTO(Guid id, string? firstName, string? lastName, EmailDTO email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public virtual Models.User ToModel(UpdateUserDTO user)
    {
        return ToModelUser(user);
    }

    public virtual IList<Models.User> ToModelList(IList<UpdateUserDTO> users)
    {
        return ToModelUserList(users);
    }

    static Models.User ToModelUser(UpdateUserDTO userDTO)
    {
        if (userDTO is null)
            return new Models.User();

        Models.User _user = new();
        _user.Id = userDTO.Id;
        _user.FirstName = userDTO.FirstName;
        _user.LastName = userDTO.LastName;
        _user.Email = new EmailDTO(userDTO.Email.Address).ToModel();
        return _user;
    }

    static IList<Models.User> ToModelUserList(IList<UpdateUserDTO> users)
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
