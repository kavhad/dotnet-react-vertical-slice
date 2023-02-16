namespace DotnetReactVerticalSlice.Features.Todo;

public static class TodoStartup
{
    public static void Register(this IServiceCollection services)
    {
        services.AddSingleton<IModelBuilder, TodoModelBuilder>();
        services.AddSingleton<IApiBuilder, TodoApiBuilder>();
    }
    
}