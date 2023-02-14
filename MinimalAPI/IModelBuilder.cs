using Microsoft.EntityFrameworkCore;

namespace MinimalAPI;

public interface IModelBuilder
{
    void BuildModel(ModelBuilder modelBuilder);
}