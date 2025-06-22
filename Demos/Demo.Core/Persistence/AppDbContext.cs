namespace Demo.Core.Persistence;

public sealed class AppDbContext : DbContext
{
    public const string ConnectionStringKey = "ConnectionStrings:DemoProjectConnectionString";

    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public AppDbContext(DbContextOptions<AppDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
        => _publishDomainEventsInterceptor = publishDomainEventsInterceptor;

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseDomainMediatorCore(_publishDomainEventsInterceptor);

        base.OnConfiguring(optionsBuilder);
    }
}
