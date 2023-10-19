namespace IbgeAPI.Enpoints.V1;

public static class IbgeFirstVersion
{
    public static IVersionedEndpointRouteBuilder? IbgeFirstVersionV1(
        this IVersionedEndpointRouteBuilder? builder, string routePrefix)
    {
        var app = builder!.MapGroup(routePrefix)
            .HasDeprecatedApiVersion(new ApiVersion(1, 0))
            .HasApiVersion(new ApiVersion(1, 1));

        app.MapPost("/ibge", async (IIbgeService Service, IbgeDTO ibge) =>
        {
            var _model = new IbgeDTO().ToModel(ibge);
            await Service.CreateAsync(_model);
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(1, 0));

        app.MapDelete("/ibge", async (IIbgeService Service, int id) =>
        {
            await Service.DeleteAsync(new Models.Ibge(id));
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(1, 0));

        app.MapGet("/ibge/city/code/{code}", async (IIbgeService Service, int code) =>
        {
            var _response = await Service.GetByCodeAsync(code);
            return _response;
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(1, 0));

        app.MapGet("/ibge/city/{city}", async (IIbgeService Service, string city) =>
        {
            var _response = await Service.GetByCityAsync(city);
            return _response;
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(1, 0));

        app.MapGet("/ibge/state/{state}", async (IIbgeService Service, string state) =>
        {
            var _response = await Service.GetByStateAsync(state);
            return _response;
        }).Produces<UserDTO>().MapToApiVersion(new ApiVersion(1, 0));

        return builder;
    }
}
