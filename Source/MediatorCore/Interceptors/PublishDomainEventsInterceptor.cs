using Mediator;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Erdmier.DomainCore.MediatorCore;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
/// <summary>
///     An EF Core interceptor that listens for the <see cref="DbContext.SaveChanges()" /> or <see cref="DbContext.SaveChangesAsync(System.Threading.CancellationToken)" />
///     operations and publishes domain events associated with domain entities - which implement <see cref="IHasDomainEvents" /> - tracked by the DbContext's ChangeTracker.
/// </summary>
/// <remarks>
///     This class intercepts database save operations to capture and publish domain events implemented via the <see cref="IDomainEvent" /> interface. Any domain events queued
///     within an entity are cleared after being published.
/// </remarks>
public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IPublisher _publisher;

    /// <summary>Instantiates a new <see cref="PublishDomainEventsInterceptor" />.</summary>
    /// <param name="publisher">The <see cref="IPublisher" /> used for publishing the domain events.</param>
    public PublishDomainEventsInterceptor(IPublisher publisher) => _publisher = publisher;

    /// <inheritdoc />
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        PublishDomainEvents(eventData.Context)
            .GetAwaiter()
            .GetResult();

        return base.SavingChanges(eventData, result);
    }

    /// <inheritdoc />
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData      eventData,
                                                                                InterceptionResult<int> result,
                                                                                CancellationToken       cancellationToken = new())
    {
        await PublishDomainEvents(eventData.Context, cancellationToken);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    /// <summary>Publishes the domain events for entities tracked by the provided <see cref="DbContext" />.</summary>
    /// <param name="dbContext">The <see cref="DbContext" /> containing entities with domain events to publish.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the publication of domain events.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    /// <remarks>
    ///     <para>
    ///         This method gets all entities that implement <see cref="IHasDomainEvents" /> from the <see cref="DbContext.ChangeTracker" /> and then publishes any domain events which
    ///         implement <see cref="IDomainEvent" /> using <see cref="IPublisher" />.
    ///     </para>
    ///     <para><b>NOTE:</b> <i>Before</i> looping through the domain events and publishing them, all captured domain events are cleared.</para>
    ///     <para>
    ///         At this time, there is no way to distinguish domain events that should be published via this interceptor or other means. Any captured domain events by an entity tracked
    ///         by the <see cref="DbContext.ChangeTracker" /> will be published. Adding a way to better handle this is planned for a future release.
    ///     </para>
    /// </remarks>
    protected virtual async Task PublishDomainEvents(DbContext? dbContext, CancellationToken cancellationToken = default)
    {
        if (dbContext is null)
        {
            return;
        }

        List<IHasDomainEvents> domainEntitiesWithEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                                                                   .Where(entry => entry.Entity.DomainEvents.Any())
                                                                   .Select(entry => entry.Entity)
                                                                   .ToList();

        if (domainEntitiesWithEvents.Count == 0)
        {
            return;
        }

        List<IDomainEvent> domainEvents = domainEntitiesWithEvents.SelectMany(entity => entity.DomainEvents)
                                                                  .ToList();

        domainEntitiesWithEvents.ForEach(entity => entity.ClearDomainEvents());

        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }
    }
}
