namespace MinimalAPI.Features.Swagger;

public class SwaggerApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}