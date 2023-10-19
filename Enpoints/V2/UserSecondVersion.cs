namespace IbgeAPI.Enpoints.V2;

public static class UserSecondVersion
{
    public static IVersionedEndpointRouteBuilder? UserSecondVersionV2(
        this IVersionedEndpointRouteBuilder? builder, string routePrefix)
    {
        var app = builder.MapGroup(routePrefix)
            .HasApiVersion(new ApiVersion(2, 0));

        app.MapPost("/user/login", async (IUserService Service, AuthDTO user) =>
        {
            var _model = new AuthDTO().ToModel(user);
            var result = await Service.Login(_model);
            return result;
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
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(2, 0)).RequireAuthorization();

        app.MapDelete("/user", async (IUserService Service, Guid id) =>
        {
            await Service.DeleteAsync(new Models.User(id));
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(2, 0)).RequireAuthorization();

        app.MapGet("/user/get-by/{email}", async (IUserService Service, string email) =>
        {
            var result = await Service.GetByEmailAsync(email);            
            return result;
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(2, 0)).RequireAuthorization();

        return builder;
    }
}
