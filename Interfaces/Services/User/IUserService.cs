﻿namespace IbgeAPI.Interfaces.Services.User;

public interface IUserService : IServiceBase<Models.User>
{
    Task SingInAsync(Models.User user);
    //Task SingOut(Models.User user);
    Task<Models.User> GetByEmailAsync(string email);
    Task<IResult> Login(Models.User user);
}
