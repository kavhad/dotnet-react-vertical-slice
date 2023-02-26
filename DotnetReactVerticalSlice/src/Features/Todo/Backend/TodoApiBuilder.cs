using Microsoft.AspNetCore.Mvc;

namespace DotnetReactVerticalSlice.Features.Todo;

public class TodoApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        string basePath = "api/v1";
        app.MapGet(basePath+"/todo-list/all", TodosAppApi.GetTodos);
        app.MapGet(basePath+"/todo-list/{id}", TodosAppApi.GetTodo);
        app.MapPost(basePath+"/todo-list", TodosAppApi.CreateTodoList);
        app.MapPut(basePath+"/todo-list/changeName", TodosAppApi.ChangeTodoListName);
        app.MapPut(basePath+"/todo-item/{id}/changeName", TodosAppApi.ChangeTodoItemName);
        app.MapPut(basePath+"/todo-item/{id}/setTodoStatus", TodosAppApi.SetTodoItemStatus);
        app.MapDelete(basePath+"/todo-list/{id}", TodosAppApi.DeleteTodoList);
        
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