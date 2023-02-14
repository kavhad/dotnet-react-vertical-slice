using System.Collections.Immutable;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.Features.Todo;

public static class TodosEndPoint
{ 
    internal static Task<IResult> GetTodos([FromServices] MinimalApiDbContext dbContext)
    {
        var todoListSet = dbContext.Set<TodoList>();
        return Task.FromResult(Results.Ok(todoListSet.ToImmutableList()));
    }

    internal static async Task<IResult> PostTodos([FromServices] MinimalApiDbContext dbContext, [FromBody] TodoList todoList)
    {
        var todoListSet = dbContext.Set<TodoList>();
        todoListSet.Add(todoList);
        await dbContext.SaveChangesAsync();
        return Results.Ok(todoList);
    }
}