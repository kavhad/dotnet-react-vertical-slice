using Microsoft.AspNetCore.Mvc;

namespace DotnetReactVerticalSlice.Features.Todo;

public class TodoApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        app.MapGet("/todo-list/all", TodosAppApi.GetTodos);
        app.MapGet("/todo-list/{id}", TodosAppApi.GetTodo);
        app.MapPost("/todo-list", TodosAppApi.CreateTodoList);
        app.MapPut("/todo-list/changeName", TodosAppApi.ChangeTodoListName);
        app.MapPut("/todo-item/{id}/changeName", TodosAppApi.ChangeTodoItemName);
        app.MapPut("/todo-item/{id}/setTodoStatus", TodosAppApi.SetTodoItemStatus);
        app.MapDelete("/todo-list/{id}", TodosAppApi.DeleteTodoList);
        
        SeedData(app);
    }

    private void SeedData(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var todoSet = db.Set<TodoList>();

        var todoList = new TodoList("DotnetReactVerticalSlice Todos");
        todoList.Todos.Add(new TodoList.Todo("Slice Everything", true));
        todoSet.Add(todoList);
        db.SaveChanges();
    }


}