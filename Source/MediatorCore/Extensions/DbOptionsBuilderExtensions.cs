namespace Erdmier.DomainCore.MediatorCore;

/// <summary>Provides extension methods for configuring <see cref="DbContextOptionsBuilder" /> with Mediator's event publishing functionality.</summary>
[ UsedImplicitly ]
public static class DbOptionsBuilderExtensions
{
    /// <summary>
    ///     Configures the <see cref="DbContextOptionsBuilder" /> to use the library's built-in interceptor - the <see cref="PublishDomainEventsInterceptor" /> - for publishing
    ///     domain events when persisting to the DB.
    /// </summary>
    /// <param name="optionsBuilder">The <see cref="DbContextOptionsBuilder" /> instance to configure.</param>
    /// <param name="interceptor">The <see cref="PublishDomainEventsInterceptor" /> that handles publishing domain events during persistence operations.</param>
    /// <returns>The configured <see cref="DbContextOptionsBuilder" /> instance.</returns>
    [ UsedImplicitly ]
    public static DbContextOptionsBuilder UseDomainMediatorCore(this DbContextOptionsBuilder optionsBuilder, PublishDomainEventsInterceptor interceptor)
    {
        optionsBuilder.AddInterceptors(interceptor);

        return optionsBuilder;
    }
}
