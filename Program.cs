using IbgeAPI.ConfigureVersioning;
using IbgeAPI.Enpoints.V1;
using IbgeAPI.Enpoints.V2;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IIbgeService, IbgeService>();
builder.Services.AddScoped<IIbgeRepository, IbgeRepository>();
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddApiVersioning(options => 
    {  
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new Asp.Versioning.ApiVersion(2);
    })
    .AddApiExplorer(options => 
    {
        //Group by version nunmber
        options.GroupNameFormat = "'v'VVV";
        // Necessario para o correto funcionamento das rotas
        options.SubstituteApiVersionInUrl = true;
    }).EnableApiVersionBinding();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

var api = app.NewVersionedApi("IBGE API");
api.UserEndpointsV1("/v{version:apiVersion}/");
api.UserEndpointsV2("/v{version:apiVersion}/");
api.IbgeEndpointsV1("/v{version:apiVersion}/");
api.IbgeEndpointsV2("/v{version:apiVersion}/");

app.UseSwagger();
app.UseSwaggerUI(options => 
{ 
    var descriptions = app.DescribeApiVersions();
    foreach(var description in descriptions)
    {
        var url = $"/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();
        options.SwaggerEndpoint(url, name);
    }
});

app.UseHttpsRedirection();

app.Run();