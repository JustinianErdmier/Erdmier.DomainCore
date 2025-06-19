using Erdmier.DomainCore.Models;

namespace Erdmier.DomainCore.Mediator;

public abstract class EntityWithDomainEvents<TId> : Entity<TId>, IHasDomainEvents
    where TId : ValueObject
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected EntityWithDomainEvents(TId id)
        : base(id)
    { }

    protected EntityWithDomainEvents()
    { }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (_domainEvents.Contains(domainEvent))
        {
            return;
        }

        _domainEvents.Add(domainEvent);
    }
}
