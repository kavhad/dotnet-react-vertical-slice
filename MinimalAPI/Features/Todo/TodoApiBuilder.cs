namespace MinimalAPI.Features.Todo;

public class TodoApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        app.MapGet("/todos", TodosEndPoint.GetTodos);
        app.MapPost("/todos", TodosEndPoint.PostTodos);
    }


}