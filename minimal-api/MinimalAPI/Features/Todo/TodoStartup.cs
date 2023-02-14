namespace MinimalAPI.Features.Todo;

public static class TodoStartup
{
    public static void RegisterTodos(this IServiceCollection services)
    {
        services.AddSingleton<IModelBuilder, TodoModelBuilder>();
        services.AddSingleton<IApiBuilder, TodoApiBuilder>();
    }
    
}