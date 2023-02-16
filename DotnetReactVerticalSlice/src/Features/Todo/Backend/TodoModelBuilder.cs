namespace DotnetReactVerticalSlice.Features.Todo;
using Microsoft.EntityFrameworkCore;

class TodoModelBuilder : IModelBuilder
{
    public void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>();
    }
}