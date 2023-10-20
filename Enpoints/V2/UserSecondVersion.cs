namespace IbgeAPI.Enpoints.V2;

public static class UserSecondVersion
{
    public static IVersionedEndpointRouteBuilder? UserSecondVersionV2(
        this IVersionedEndpointRouteBuilder? builder, string routePrefix)
    {
        var app = builder.MapGroup(routePrefix)
            .HasApiVersion(new ApiVersion(2, 0))
            .WithTags("User");

        app.MapPost("/user/login", async (IUserService Service, AuthDTO user) =>
        {
            var _model = new AuthDTO().ToModel(user);
            return await Service.Login(_model);
        }).Produces<AuthorizedResponse>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapPost("/user", async (IUserService Service, CreateUserDTO user) =>
        {
            var _model = new CreateUserDTO().ToModel(user);
            return await Service.SingInAsync(_model);
        }).Produces<CreatedUserResponse>().MapToApiVersion(new ApiVersion(2, 0));       

        /*app.MapPut("/user", async (IUserService Service, UpdateUserDTO user) =>
        {
            var _model = new UpdateUserDTO().ToModel(user);
            return await Service.UpdateAsync(_model);
        }).Produces<UpdatedUserResponse>().MapToApiVersion(new ApiVersion(2, 0)).RequireAuthorization();

        app.MapDelete("/user", async (IUserService Service, Guid id) =>
        {
            return await Service.DeleteAsync(new Models.User(id));
        }).Produces<DeletedUserResponse>().MapToApiVersion(new ApiVersion(2, 0)).RequireAuthorization();

        app.MapGet("/user/get-by/{email}", async (IUserService Service, string email) =>
        {
            var result = await Service.GetByEmailAsync(email);            
            return result;
        }).Produces<GetedUserResponse>().MapToApiVersion(new ApiVersion(2, 0)).RequireAuthorization();*/

        return builder;
    }
}
