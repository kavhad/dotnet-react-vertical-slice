namespace MinimalAPI.Features.Swagger;

public static class SwaggerStartup
{
    public static void Register(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<IApiBuilder, SwaggerApiBuilder>();
    }
}