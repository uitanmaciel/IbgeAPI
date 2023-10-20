namespace IbgeAPI.Enpoints.V1;

public static class UserFirstVersion
{
    public static IVersionedEndpointRouteBuilder? UserFirstVersionV1(
        this IVersionedEndpointRouteBuilder? builder, string routePrefix)
    {
        var app = builder!.MapGroup(routePrefix)
            .HasDeprecatedApiVersion(new ApiVersion(1,0))
            .HasApiVersion(new ApiVersion(1, 1));

        app.MapPost("/user", async (IUserService Service, CreateUserDTO user) =>
        {
            var _model = new CreateUserDTO().ToModel(user);
            await Service.SingInAsync(_model);
        }).Produces<CreatedUserResponse>().MapToApiVersion(new ApiVersion(1, 0));

        app.MapPut("/user", async (IUserService Service, CreateUserDTO user) =>
        {
            var _model = new CreateUserDTO().ToModel(user);
            await Service.UpdateAsync(_model);
        }).Produces<CreatedUserResponse>().MapToApiVersion(new ApiVersion(1, 0));

        app.MapDelete("/user", async (IUserService Service, Guid id) =>
        {
            await Service.DeleteAsync(new Models.User(id));
        }).Produces<CreatedUserResponse>().MapToApiVersion(new ApiVersion(1, 0));

        return builder;
    }
}
