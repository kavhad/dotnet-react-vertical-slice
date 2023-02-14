using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MinimalAPI;
using MinimalAPI.Features.Todo;

[assembly: InternalsVisibleTo("MinimalAPI.Tests")]

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterTodos();
builder.Services.AddDbContext<MinimalApiDbContext>(options => options.UseInMemoryDatabase("MinimalApi"));

var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async (context) =>
    {
        var ehpF = context.Features.Get<IExceptionHandlerPathFeature>();
        
        if (ehpF?.Error is ArgumentException)
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        
        await context.Response.WriteAsJsonAsync(
            ehpF?.Error switch
            {
                ArgumentException exception  => new ErrorResult(exception.Message, DateTime.Now, exception.ParamName),
                { } exception => new ErrorResult(exception.Message, DateTime.Now),
                _ => new ErrorResult("Unknown Error", DateTime.Now)
            });
        
    });
});

app.MapGet("/", () => "Hello World!");

foreach (var apiBuilder in app.Services.GetService<IEnumerable<IApiBuilder>>()!)
{
    apiBuilder.BuildApi(app);
}

app.Run();

record ErrorResult(string Message, DateTime Time, string? Param = null); 