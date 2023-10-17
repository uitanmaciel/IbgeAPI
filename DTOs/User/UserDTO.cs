namespace IbgeAPI.DTOs.User;

public class UserDTO : ApiResult<UserDTO>
{
    private Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public EmailDTO Email { get; set; } = null!;
    public PasswordDTO Password { get; set; } = null!;

    public UserDTO() { }

    public UserDTO(Guid id)
    {
        Id = id;
    }

    public UserDTO(Guid id, string? firstName, string? lastName, EmailDTO email, PasswordDTO password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public virtual Models.User ToModel(UserDTO user) 
    {
        return ToModelUser(user);
    }

    public virtual IList<Models.User> ToModelList(IList<UserDTO> users)
    {
        return ToModelUserList(users);
    }

    public virtual UserDTO ToDTO(Models.User user)
    {
        return ToDTOUser(user);
    }

    public virtual IList<UserDTO> ToDTOList(IList<Models.User> users) 
    { 
        return ToDTOUserList(users);
    }

    static Models.User ToModelUser(UserDTO userDTO)
    {
        if(userDTO is null)
            return new Models.User();

        Models.User _user = new();

        if (_user.Id != Guid.Empty) _user.Id = userDTO.Id;
        else _user.Id = Guid.NewGuid();

        _user.FirstName = userDTO.FirstName;
        _user.LastName = userDTO.LastName;
        _user.Email =  new EmailDTO(userDTO.Email.Address).ToModel();
        _user.Password = new PasswordDTO(userDTO.Password.Password).ToModel();
        return _user;
    }

    static IList<Models.User> ToModelUserList(IList<UserDTO> users)
    {
        List<Models.User> _usersList = new();
        if(users is not null)
        {
            foreach(var user in users)
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

    static UserDTO ToDTOUser(Models.User user)
    {
        if(user is null)
            return new UserDTO();

        UserDTO _user = new();
        _user.Id = user.Id;
        _user.FirstName = user.FirstName;
        _user.LastName = user.LastName;
        _user.Email = new EmailDTO().ToDTO(user.Email);        
        return _user;
    }

    static IList<UserDTO> ToDTOUserList(IList<Models.User> users)
    {
        List<UserDTO> _usersList = new();
        if(users is not null)
        {
            foreach (var user in users)
            {
                UserDTO _user = new();
                _user.Id = user.Id;
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.Email = new EmailDTO().ToDTO(user.Email);
                _usersList.Add(_user);
            }
        }
        return _usersList;
    }
}
