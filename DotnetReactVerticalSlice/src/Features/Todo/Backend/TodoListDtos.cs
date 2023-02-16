using System.Text.Json.Serialization;

namespace DotnetReactVerticalSlice.Features.Todo;

public record TodoListDto(int id, string name, List<TodoItemDto> list)
{
    public TodoListDto(TodoList input): 
        this(input.Id, input.Name, input.Todos.Select(ti => new TodoItemDto(ti.Id, ti.Name, ti.IsComplete))
            .ToList()) {}
}
public record TodoItemDto(int id, string name, bool isComplete);

public record NewTodoListDto
{
    public string Name { get; }
    public List<NewTodoItem> List { get; }

    [JsonConstructor]
    public NewTodoListDto(string name, List<NewTodoItem> list) =>
        (Name, List) = (TodoList.NameValidator.Validate(name), list);
}
public record NewTodoItem(String name, bool isComplete);
public record ChangeTodoListNameDto
{
    public int Id { get; }
    public String Name { get; }

    [JsonConstructor]
    public ChangeTodoListNameDto(int id, string name) => 
        (Id, Name) = (id, TodoList.NameValidator.Validate(name));

}

public record ChangeTodoItemNameDto
{
    public String Name { get; }

    [JsonConstructor]
    public ChangeTodoItemNameDto(string name) => 
        Name = TodoList.NameValidator.Validate(name);
}

public record ChangeTodoItemStatusDto(bool IsComplete);
