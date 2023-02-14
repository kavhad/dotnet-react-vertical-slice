namespace MinimalAPI.Features.Todo;

public class TodoApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        app.MapGet("/todos", TodosAppApi.GetTodos);
        app.MapGet("/todos/{id}", TodosAppApi.GetTodo);
        app.MapPost("/todos", TodosAppApi.CreateTodoList);
        app.MapPut("/todos/changeName", TodosAppApi.ChangeTodoListName);
        app.MapPut("/todo-item/{id}/changeName", TodosAppApi.ChangeTodoItemName);
        app.MapPut("/todo-item/{id}/setTodoStatus", TodosAppApi.SetTodoItemStatus);
    }


}