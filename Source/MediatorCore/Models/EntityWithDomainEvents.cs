namespace Erdmier.DomainCore.MediatorCore;

/// <summary>Represents a base entity in the domain model which can be uniquely identified by an ID of type <typeparamref name="TId" />.</summary>
/// <typeparam name="TId">The type of the unique identifier for this entity, which must derive from <see cref="ValueObject" />.</typeparam>
/// <remarks>This model has a list of <see cref="IDomainEvent" />s which implement Mediator's <see cref="INotification" />.</remarks>
public abstract class EntityWithDomainEvents<TId> : Entity<TId>, IHasDomainEvents
    where TId : ValueObject
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>Instantiates a new <see cref="EntityWithDomainEvents{TId}" />.</summary>
    /// <param name="id">The unique identifier of the instance.</param>
    protected EntityWithDomainEvents(TId id)
        : base(id)
    { }

    /// <summary>Instantiates a new <see cref="EntityWithDomainEvents{TId}" />.</summary>
    protected EntityWithDomainEvents()
    { }

    /// <summary>Gets a <see cref="IReadOnlyList{T}" /> of <see cref="IDomainEvent" />s for this entity.</summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>Clears all <see cref="IDomainEvent" />s for this entity.</summary>
    public void ClearDomainEvents() => _domainEvents.Clear();

    /// <summary>Adds an <see cref="IDomainEvent" /> to this entity.</summary>
    /// <param name="domainEvent">The <see cref="IDomainEvent" /> to be added.</param>
    /// <remarks>If the <paramref name="domainEvent" /> is already added, it will not be added again.</remarks>
    [ UsedImplicitly ]
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (_domainEvents.Contains(domainEvent))
        {
            return;
        }

        _domainEvents.Add(domainEvent);
    }
}
