using Asp.Versioning.Builder;
using Asp.Versioning;

namespace IbgeAPI.Enpoints.V2;

public static class User
{
    public static IVersionedEndpointRouteBuilder? UserEndpointsV2(
        this IVersionedEndpointRouteBuilder? builder, string routePrefix)
    {
        var app = builder.MapGroup(routePrefix)
            .HasApiVersion(new ApiVersion(2, 0));

        app.MapPost("/user/login", async (IUserService Service, DTOs.Auth.UserAuthDTO user) =>
        {
            var _model = new DTOs.Auth.UserAuthDTO().ToModel(user);
            await Service.Login(_model);
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapPost("/user", async (IUserService Service, UserDTO user) =>
        {
            var _model = new UserDTO().ToModel(user);
            await Service.SingInAsync(_model);
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapPut("/user", async (IUserService Service, UserDTO user) =>
        {
            var _model = new UserDTO().ToModel(user);
            await Service.UpdateAsync(_model);
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapDelete("/user", async (IUserService Service, Guid id) =>
        {
            await Service.DeleteAsync(new Models.User(id));
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapGet("/user/get-by/{email}", async (IUserService Service, string email) =>
        {
            var _model = await Service.GetByEmailAsync(email);
            var _user = new UserDTO().ToDTO(_model);
            return _user;
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(2, 0));

        return builder;
    }
}
