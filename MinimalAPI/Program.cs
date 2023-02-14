using Microsoft.EntityFrameworkCore;
using MinimalAPI;
using MinimalAPI.Features.Todo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterTodos();
builder.Services.AddDbContext<MinimalApiDbContext>(options => options.UseInMemoryDatabase("MinimalApi"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

foreach (var apiBuilder in app.Services.GetService<IEnumerable<IApiBuilder>>()!)
{
    apiBuilder.BuildApi(app);
}

app.Run();
