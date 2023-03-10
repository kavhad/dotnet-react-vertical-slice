using Microsoft.EntityFrameworkCore;

namespace DotnetReactVerticalSlice;

/// <summary>
/// A plugin interface that enables a feature to build entity models associated with the AppDbContext
/// </summary>
public interface IModelBuilder
{
    void BuildModel(ModelBuilder modelBuilder);
}