using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using DotnetReactVerticalSlice;

[assembly: InternalsVisibleTo("DotnetReactVerticalSlice.Tests")]

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterAllFeatures();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MinimalApi"));

var app = builder.Build();

app.UseStaticFiles();

GlobalErrorHandler.Register(app);

foreach (var apiBuilder in app.Services.GetService<IEnumerable<IApiBuilder>>()!)
{
    apiBuilder.BuildApi(app);
}

app.MapFallbackToFile("index.html");
app.Run();

