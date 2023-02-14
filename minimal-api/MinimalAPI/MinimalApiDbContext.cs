using System.Collections.Immutable;

namespace MinimalAPI;
using Microsoft.EntityFrameworkCore;

partial class MinimalApiDbContext : DbContext
{
    private readonly ImmutableList<IModelBuilder> _modelBuilders;

    public MinimalApiDbContext(
        IEnumerable<IModelBuilder> modelBuilders,
        DbContextOptions<MinimalApiDbContext> options) : base(options)
    {
        _modelBuilders = modelBuilders.ToImmutableList();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _modelBuilders.ForEach(mb => mb.BuildModel(modelBuilder));
        
        base.OnModelCreating(modelBuilder);
    }
}