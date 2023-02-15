using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace MinimalAPI;

internal static class GlobalErrorHandler
{
    internal static void Register(WebApplication app)
    {
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
    }
}

record ErrorResult(string Message, DateTime Time, string? Param = null);