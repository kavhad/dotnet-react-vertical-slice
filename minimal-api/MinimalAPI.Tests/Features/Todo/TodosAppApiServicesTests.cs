using System.Collections.Immutable;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Features.Todo;

namespace MinimalAPI.Tests.Features.Todo;

public class TodosAppApiServicesTests
{

    private readonly MinimalApiDbContext _dbContext =
        new(
            new []{ new TodoModelBuilder() },
            new DbContextOptionsBuilder<MinimalApiDbContext>()
                .UseInMemoryDatabase(databaseName: "MinimalAPI")
                .Options
        );

    [Fact]
    public async Task GetTodosTest()
    {
        //Arrange setup dbContext
        
        //Act
        var results = (Ok<List<TodoListDto>>) await TodosAppApi.GetTodos(_dbContext);
        
        //Assert
        Assert.Equal(200, results.StatusCode);
        Assert.Equal(0, results.Value?.Count);
    }

    [Fact]
    public async Task CreateNewTodoTests()
    {
        //Act
        var results = (Ok<TodoList>) await TodosAppApi.CreateTodoList(_dbContext,
            new NewTodoListDto("test-list", 
                new List<NewTodoItem>(new[] { new NewTodoItem("test-item", false) })));
        
        //Assert
        Assert.Equal(200, results.StatusCode);
        Assert.Equal(1, results.Value?.Id);
        Assert.Equal("test-list", results.Value?.Name);
        Assert.Equal("test-item", results.Value?.Todos.Single().Name);
        Assert.Equal(false, results.Value?.Todos.Single().IsComplete);
    }
    
    [Fact]
    public async Task GetTodo()
    {
        //Arrange

        var todoList = new TodoList("test-list");
        todoList.Todos.Add(new TodoList.Todo("item1", true));
        _dbContext.Set<TodoList>().Add(todoList);
        await _dbContext.SaveChangesAsync();
        
        //Act
        var results = (Ok<TodoListDto>) await TodosAppApi.GetTodo(_dbContext, 1); //assuming initial id is 1
        
        //Assert
        Assert.Equal(200, results.StatusCode);
        Assert.Equal(1, results.Value?.id);
        Assert.Equal("test-list", results.Value?.name);
        Assert.Equal("item1", results.Value?.list.Single().name);
        Assert.Equal(true, results.Value?.list.Single().isComplete);
    }
}