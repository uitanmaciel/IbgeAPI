var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IIbgeService, IbgeService>();
builder.Services.AddScoped<IIbgeRepository, IbgeRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Enpoints User
app.MapPost("/login", async (IUserService Service, IbgeAPI.DTOs.Auth.UserAuthDTO user) => 
{
    var _model = new IbgeAPI.DTOs.Auth.UserAuthDTO().ToModel(user);
    await Service.Login(_model);
});

app.MapPost("/user", async (IUserService Service, UserDTO user) =>
{    
    var _model = new UserDTO().ToModel(user);
    await Service.SingInAsync(_model);
});

app.MapPut("/user", async (IUserService Service, UserDTO user) => 
{
    var _model = new UserDTO().ToModel(user);
    await Service.UpdateAsync(_model);
});

app.MapDelete("/user", async(IUserService Service, Guid id) => 
{
    await Service.DeleteAsync(new User(id));
});

app.MapGet("/user/{id}", async (IUserService Service, Guid id) =>
{ 
    var _model = await Service.GetByIdAsync(new User(id));
    var _user = new UserDTO().ToDTO(_model);
    return _user;
});

app.MapGet("/user", async(IUserService Service) => 
{ 
    var _models = await Service.GetAllAsync();
    var _users = new UserDTO().ToDTOList(_models.ToList());
    return _users;
});

app.MapGet("/user/get-by/{email}", async (IUserService Service, string email) => 
{ 
    var _model = await Service.GetByEmailAsync(email);
    var _user = new UserDTO().ToDTO(_model);
    return _user;
});
#endregion
#region Enpoints Ibge
app.MapPost("/ibge", async (IIbgeService Service, IbgeDTO ibge) => 
{ 
    var _model = new IbgeDTO().ToModel(ibge);
    await Service.CreateAsync(_model);
});

app.MapDelete("/ibge", async (IIbgeService Service, int id) => 
{
    await Service.DeleteAsync(new Ibge(id));
});

app.MapGet("/ibge/city/code/{code}", async (IIbgeService Service, int code) => 
{
    var _model = await Service.GetByCodeAsync(code);
    var _city = new IbgeDTO().ToDTO(_model);
    return _city;
});

app.MapGet("/ibge/city/{city}", async (IIbgeService Service, string city) => 
{ 
    var _models = await Service.GetByCityAsync(city);
    var _cities = new IbgeDTO().ToDTOList(_models);
    return _cities;
});

app.MapGet("/ibge/state/{state}", async (IIbgeService Service, string state) => 
{ 
    var _models = await Service.GetByStateAsync(state);
    var _states = new IbgeDTO().ToDTOList(_models);
    return _states;
});

app.MapGet("/ibge/state/{state}/city/{city}", async(IIbgeService Service, string state, string city) => 
{ 
    var _models = await Service.GetByStateAndCityAsync(state, city);
    var _result = new IbgeDTO().ToDTOList(_models);
    return _result;
});
#endregion

app.Run();