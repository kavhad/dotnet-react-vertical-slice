using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace DotnetReactVerticalSlice.Features.Todo;

public class TodosAppApiTests
{

    private class TestDbContextHolder : IDisposable
    {
        public AppDbContext DbContext { get; }
        public TestDbContextHolder()
        {
            DbContext =  new AppDbContext(
                new []{ new TodoModelBuilder() },
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "DotnetReactVerticalSlice")
                    .Options
            );
        }
        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Dispose();
        }
    }

    [Fact]
    public async Task GetTodosTest()
    {
        //Arrange setup dbContext
        using var dbContextHolder = new TestDbContextHolder();
        var dbContext = dbContextHolder.DbContext;
        
        //Act
        var results = (Ok<List<TodoListDto>>) await TodosAppApi.GetTodos(dbContext);
        
        //Assert
        Assert.Equal(200, results.StatusCode);
        Assert.Equal(0, results.Value?.Count);
    }

    [Fact]
    public async Task CreateNewTodoTests()
    {
        //Arrange
        using var dbContextHolder = new TestDbContextHolder();
        var dbContext = dbContextHolder.DbContext;
        
        //Act
        var results = (Ok<TodoListDto>) await TodosAppApi.CreateTodoList(dbContext,
            new NewTodoListDto("test-list", 
                new List<NewTodoItem>(new[] { new NewTodoItem("test-item", false) })));
        
        //Assert
        Assert.Equal(200, results.StatusCode);
        Assert.Equal(1, results.Value?.id);
        Assert.Equal("test-list", results.Value?.name);
        Assert.Equal("test-item", results.Value?.list.Single().name);
        Assert.Equal(false, results.Value?.list.Single().isComplete);
    }
    
    [Fact]
    public async Task GetTodo()
    {
        //Arrange
        using var dbContextHolder = new TestDbContextHolder();
        var dbContext = dbContextHolder.DbContext;

        var todoList = new TodoList("test-list");
        todoList.Todos.Add(new TodoList.Todo("item1", true));
        dbContext.Set<TodoList>().Add(todoList);
        await dbContext.SaveChangesAsync();
        
        //Act
        var results = (Ok<TodoListDto>) await TodosAppApi.GetTodo(dbContext, 1); //assuming initial id is 1
        
        //Assert
        Assert.Equal(200, results.StatusCode);
        Assert.Equal(1, results.Value?.id);
        Assert.Equal("test-list", results.Value?.name);
        Assert.Equal("item1", results.Value?.list.Single().name);
        Assert.Equal(true, results.Value?.list.Single().isComplete);
    }
}