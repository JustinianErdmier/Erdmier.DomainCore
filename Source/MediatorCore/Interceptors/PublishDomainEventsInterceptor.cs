using Mediator;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Erdmier.DomainCore.MediatorCore;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IPublisher _publisher;

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
