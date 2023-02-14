namespace MinimalAPI.Features.Todo;

public class TodoApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        app.MapGet("/todos", TodosEndPoint.GetTodos);
        app.MapPost("/todos", TodosEndPoint.CreateTodoList);
        app.MapPut("/todos/changeName", TodosEndPoint.ChangeTodoListName);
        app.MapPut("/todo-item/{id}/changeName", TodosEndPoint.ChangeTodoItemName);
        app.MapPut("/todo-item/{id}/setTodoStatus", TodosEndPoint.SetTodoItemStatus);
    }


}