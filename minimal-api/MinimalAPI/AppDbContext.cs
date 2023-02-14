using System.Collections.Immutable;

namespace MinimalAPI;
using Microsoft.EntityFrameworkCore;

internal class AppDbContext : DbContext
{
    private readonly ImmutableList<IModelBuilder> _modelBuilders;

    public AppDbContext(
        IEnumerable<IModelBuilder> modelBuilders,
        DbContextOptions<AppDbContext> options) : base(options)
    {
        _modelBuilders = modelBuilders.ToImmutableList();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _modelBuilders.ForEach(mb => mb.BuildModel(modelBuilder));
        
        base.OnModelCreating(modelBuilder);
    }
}