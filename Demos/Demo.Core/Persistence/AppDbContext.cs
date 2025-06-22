namespace Demo.Core.Persistence;

public sealed class AppDbContext : DbContext
{
    public const string ConnectionStringKey = "ConnectionStrings:DemoProjectConnectionString";

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
