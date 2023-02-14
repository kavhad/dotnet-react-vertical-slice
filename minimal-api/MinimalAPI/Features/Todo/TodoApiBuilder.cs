namespace MinimalAPI.Features.Todo;

public class TodoApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        app.MapGet("/todos", TodosAppApiServices.GetTodos);
        app.MapGet("/todos/{id}", TodosAppApiServices.GetTodo);
        app.MapPost("/todos", TodosAppApiServices.CreateTodoList);
        app.MapPut("/todos/changeName", TodosAppApiServices.ChangeTodoListName);
        app.MapPut("/todo-item/{id}/changeName", TodosAppApiServices.ChangeTodoItemName);
        app.MapPut("/todo-item/{id}/setTodoStatus", TodosAppApiServices.SetTodoItemStatus);
    }


}