using System.Collections.Immutable;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Features.Todo;

public static class TodosEndPoint
{ 
    internal static Task<IResult> GetTodos([FromServices] MinimalApiDbContext dbContext)
    {
        var todoListSet = 
            dbContext.Set<TodoList>();
        return Task.FromResult(
            Results.Ok(
                todoListSet.Include(
                    todoList => todoList.Todos).ToImmutableList()));
    }

    internal static async Task<IResult> CreateTodoList([FromServices] MinimalApiDbContext dbContext, [FromBody] NewTodoListDto newTodoListDto)
    {
        var todoListSet = dbContext.Set<TodoList>();
        var todoListResult = TodoList.NewTodoList(newTodoListDto);
        todoListSet.Add(todoListResult);
        await dbContext.SaveChangesAsync();
        return Results.Ok(todoListResult);
    }

    internal static async Task<IResult> ChangeTodoListName([FromServices] MinimalApiDbContext dbContext,
        [FromBody] ChangeTodoListNameDto changeTodoListNameDto)
    {
        var todoList = await dbContext.Set<TodoList>().FindAsync(changeTodoListNameDto.Id);
        if (todoList is null)
            return Results.NotFound();

        todoList.SetName(changeTodoListNameDto.Name);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    internal static async Task<IResult> ChangeTodoItemName([FromServices] MinimalApiDbContext dbContext,
        int id, [FromBody] ChangeTodoItemNameDto changeTodoItemNameDto)
    {
        var todoItem = await dbContext.Set<TodoList.Todo>().FindAsync(id);
        if (todoItem is null)
            return Results.NotFound();
        todoItem.SetName(changeTodoItemNameDto.Name);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
        
    }
    
    internal static async Task<IResult> SetTodoItemStatus([FromServices] MinimalApiDbContext dbContext,
        int id, [FromBody] SetTodoStatusDto setTodoStatusDto)
    {
        var todoItem = await dbContext.Set<TodoList.Todo>().FindAsync(id);
        if (todoItem is null)
            return Results.NotFound();
        todoItem.SetIsComplete(setTodoStatusDto.IsComplete);
        await dbContext.SaveChangesAsync();
        
        return Results.Ok();
        
    }
}