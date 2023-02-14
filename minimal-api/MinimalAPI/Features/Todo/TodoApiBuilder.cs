namespace MinimalAPI.Features.Todo;

public class TodoApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        app.MapGet("/todos", TodosAppServices.GetTodos);
        app.MapGet("/todos/{id}", TodosAppServices.GetTodo);
        app.MapPost("/todos", TodosAppServices.CreateTodoList);
        app.MapPut("/todos/changeName", TodosAppServices.ChangeTodoListName);
        app.MapPut("/todo-item/{id}/changeName", TodosAppServices.ChangeTodoItemName);
        app.MapPut("/todo-item/{id}/setTodoStatus", TodosAppServices.SetTodoItemStatus);
    }


}