using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace DotnetReactVerticalSlice;

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
                else if (ehpF?.Error is not null)
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
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