using JetBrains.Annotations;

namespace Erdmier.DomainCore.Mediator;

/// <summary>Represents an abstraction for domain model entities capable of capturing domain events.</summary>
/// <remarks>
///     Implementing this interface allows entities to store and manage domain events (<see cref="IDomainEvent" />), which can be processed or dispatched by the application for
///     various purposes such as notifications, database updates, or integration tasks.
/// </remarks>
public interface IHasDomainEvents
{
    [ UsedImplicitly ]
    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    [ UsedImplicitly ]
    public void ClearDomainEvents();
}
