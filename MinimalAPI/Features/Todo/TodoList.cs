namespace MinimalAPI.Features.Todo;

public class TodoList
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public virtual IList<Todo> Todos { get; set; } = new List<Todo>();

    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
