using System.Text.Json.Serialization;

namespace MinimalAPI.Features.Todo;

public record TodoListDto(int id, string name, List<TodoItemDto> list);
public record TodoItemDto(int id, string name, bool isComplete);

public record NewTodoListDto
{
    public string Name { get; }
    public List<NewTodo> List { get; }

    [JsonConstructor]
    public NewTodoListDto(string name, List<NewTodo> list) =>
        (Name, List) = (TodoList.NameValidator.Validate(name), list);
}
public record NewTodo(String name, bool isComplete);
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

public record SetTodoStatusDto(bool IsComplete);
