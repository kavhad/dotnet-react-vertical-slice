using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace MinimalAPI.Features.Todo;

public class TodoList
{
    public TodoList(string name) =>
        Name = NameValidator.Validate(name);

    public int Id { get; private set; }
    public string Name { get; private set; }

    internal void SetName(string name) =>
        Name = NameValidator.Validate(name);

    public virtual IList<Todo> Todos { get; private set; } = new List<Todo>();

    public class Todo
    {
        public Todo(string name, bool isComplete)
        {
            Name = NameValidator.Validate(name);
            IsComplete = isComplete;
        }
        
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsComplete { get; private set; }
        internal void SetName(string name)
        {
            Name = NameValidator.Validate(name);
        }
        internal void SetIsComplete(bool isComplete)
        {
            IsComplete = isComplete;
        }
    }

    public static TodoList NewTodoList(NewTodoListDto dto)
    {
        var todoList = new TodoList(dto.Name);
        foreach (var todo in dto.List.Select(d => new Todo(d.name, d.isComplete)))
        {
            todoList.Todos.Add(todo);
        }

        return todoList;
    }

    internal static class NameValidator
    {
        public static string Validate(string name) =>
            string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentException("Name must not be null or empty", nameof(name))
                : name;
    }
}

