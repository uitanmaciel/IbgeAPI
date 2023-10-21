namespace IbgeAPI.Enpoints.V2;

public static class IbgeSecondVersion
{
    public static IVersionedEndpointRouteBuilder? IbgeSecondVersionV2(
        this IVersionedEndpointRouteBuilder? builder, string routePrefix)
    {
        var app = builder.MapGroup(routePrefix)
            .HasApiVersion(new ApiVersion(2, 0))
            .WithTags("IBGE");


        app.MapPost("/ibge", async (IIbgeService Service, IbgeDTO ibge) =>
        {
            var _model = new IbgeDTO().ToModel(ibge);
            return await Service.CreateAsync(_model);
        }).Produces<IbgeResponse>().MapToApiVersion(new ApiVersion(2, 0)).WithSummary("").RequireAuthorization();

        app.MapPut("/ibge", async (IIbgeService Service, IbgeDTO ibge) => 
        {
            var _model = new IbgeDTO().ToModel(ibge);
            return await Service.UpdateAsync(_model);
        }).Produces<IbgeResponse>().MapToApiVersion(new ApiVersion(2, 0)).RequireAuthorization();

        app.MapDelete("/ibge", async (IIbgeService Service, int id) =>
        {
            return await Service.DeleteAsync(new Models.Ibge(id));
        }).Produces<CreatedUserResponse>().MapToApiVersion(new ApiVersion(2, 0)).RequireAuthorization();

        app.MapGet("/ibge/", async (IIbgeService Service, int? skip, int? take) =>
        {
            var _response = await Service.GetAllAsync(skip, take);
            return _response;
        }).Produces<IbgeResponse>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapGet("/ibge/city/code/{code}", async (IIbgeService Service, int code) =>
        {
            var _response = await Service.GetByCodeAsync(code);
            return _response;
        }).Produces<IbgeResponse>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapGet("/ibge/city/{city}", async (IIbgeService Service, string city) =>
        {
            var _response = await Service.GetByCityAsync(city);
            return _response;
        }).Produces<IbgeResponse>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapGet("/ibge/state/{state}", async (IIbgeService Service, string state, int skip, int take) =>
        {
            var _response = await Service.GetByStateAsync(state, skip, take);
            return _response;
        }).Produces<IbgeResponse>().MapToApiVersion(new ApiVersion(2, 0));

        app.MapGet("/ibge/state/{state}/city/{city}", async (IIbgeService Service, string state, string city) =>
        {
            var _response = await Service.GetByStateAndCityAsync(state, city);
            return _response;
        }).Produces<IbgeResponse>().MapToApiVersion(new ApiVersion(2, 0));

        return builder;
    }
}
