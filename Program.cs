var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var key = Encoding.ASCII.GetBytes(Settings.Secrect);
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
        options.GroupNameFormat = "'v'VVV";        
        options.SubstituteApiVersionInUrl = true;
    }).EnableApiVersionBinding();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SwaggerDefaultValues>();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
    { 
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: \\\"Bearer 12345abcdef\\\"\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication(x => 
{ 
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => 
{ 
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
builder.Services.AddAuthorization();
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();

var api = app.NewVersionedApi("IBGE API");
api.UserFirstVersionV1("/v{version:apiVersion}/");
api.UserSecondVersionV2("/v{version:apiVersion}/");
api.IbgeFirstVersionV1("/v{version:apiVersion}/");
api.IbgeSecondVersionV2("/v{version:apiVersion}/");

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