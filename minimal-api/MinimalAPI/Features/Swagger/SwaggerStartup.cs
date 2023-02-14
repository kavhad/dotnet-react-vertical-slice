namespace MinimalAPI.Features.Swagger;

public static class SwaggerStartup
{
    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<IApiBuilder, SwaggerApiBuilder>();
    }
}