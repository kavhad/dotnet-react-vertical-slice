using System.Collections.Immutable;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Features.Todo;

public static class TodosAppApi
{ 
    internal static async Task<IResult> GetTodos([FromServices] AppDbContext dbContext)
    {
        var todoListSet = 
            dbContext.Set<TodoList>();
        return Results.Ok(
                await todoListSet.Include(todoList => todoList.Todos)
                    .Select(it =>
                        new TodoListDto(it.Id, it.Name,
                            it.Todos.Select(it2 => new TodoItemDto(it2.Id, it2.Name, it2.IsComplete)
                            ).ToList()
                        )
                    ).ToListAsync()
            );
    }
    
    internal static async Task<IResult> GetTodo([FromServices] AppDbContext dbContext, int id)
    {
        var todoListSet = 
            dbContext.Set<TodoList>();

        var todoList =
            await todoListSet
                .Include(todoList => todoList.Todos)
                .SingleOrDefaultAsync(x => x.Id == id);

        if (todoList is null)
            return Results.NotFound();

        return Results.Ok(new TodoListDto(todoList.Id, todoList.Name,
                todoList.Todos.Select(it2 => new TodoItemDto(it2.Id, it2.Name, it2.IsComplete)
            ).ToList()));
    }

    internal static async Task<IResult> CreateTodoList([FromServices] AppDbContext dbContext, [FromBody] NewTodoListDto newTodoListDto)
    {
        var todoListSet = dbContext.Set<TodoList>();
        var todoListResult = TodoList.NewTodoList(newTodoListDto);
        todoListSet.Add(todoListResult);
        await dbContext.SaveChangesAsync();
        return Results.Ok(todoListResult);
    }

    internal static async Task<IResult> ChangeTodoListName([FromServices] AppDbContext dbContext,
        [FromBody] ChangeTodoListNameDto changeTodoListNameDto)
    {
        var todoList = await dbContext.Set<TodoList>().FindAsync(changeTodoListNameDto.Id);
        if (todoList is null)
            return Results.NotFound();

        todoList.SetName(changeTodoListNameDto.Name);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    internal static async Task<IResult> ChangeTodoItemName([FromServices] AppDbContext dbContext,
        int id, [FromBody] ChangeTodoItemNameDto changeTodoItemNameDto)
    {
        var todoItem = await dbContext.Set<TodoList.Todo>().FindAsync(id);
        if (todoItem is null)
            return Results.NotFound();
        todoItem.SetName(changeTodoItemNameDto.Name);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
        
    }
    
    internal static async Task<IResult> SetTodoItemStatus([FromServices] AppDbContext dbContext,
        int id, [FromBody] ChangeTodoItemStatusDto changeTodoItemStatusDto)
    {
        var todoItem = await dbContext.Set<TodoList.Todo>().FindAsync(id);
        if (todoItem is null)
            return Results.NotFound();
        todoItem.SetIsComplete(changeTodoItemStatusDto.IsComplete);
        await dbContext.SaveChangesAsync();
        
        return Results.Ok();
        
    }
}