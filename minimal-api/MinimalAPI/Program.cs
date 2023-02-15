using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using MinimalAPI;

[assembly: InternalsVisibleTo("MinimalAPI.Tests")]

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterAllFeatures();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MinimalApi"));

var app = builder.Build();

GlobalErrorHandler.Register(app);

foreach (var apiBuilder in app.Services.GetService<IEnumerable<IApiBuilder>>()!)
{
    apiBuilder.BuildApi(app);
}

app.Run();

