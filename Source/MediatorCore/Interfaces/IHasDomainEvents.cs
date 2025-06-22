using JetBrains.Annotations;

namespace Erdmier.DomainCore.MediatorCore;

/// <summary>Represents an abstraction for domain model entities capable of capturing domain events.</summary>
/// <remarks>
///     Implementing this interface allows entities to store and manage domain events (<see cref="IDomainEvent" />), which can be processed or dispatched by the application for
///     various purposes such as notifications, database updates, or integration tasks.
/// </remarks>
public interface IHasDomainEvents
{
    /// <summary>Gets the collection of domain events associated with the entity.</summary>
    /// <remarks>
    ///     <para>
    ///         Domain events represent significant events or changes within the entity's domain logic. These events are stored and can be processed or dispatched to trigger additional
    ///         behaviors, such as notifying other components, updating external systems, or initiating workflows.
    ///     </para>
    ///     <para>The collection is read-only, ensuring the encapsulated events remain immutable outside the entity's control.</para>
    /// </remarks>
    [ UsedImplicitly ]
    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>Clears all the domain events associated with the entity.</summary>
    /// <remarks>
    ///     This method is used to remove all captured domain events from the entity after they have been handled or published. It prevents the same domain events from being
    ///     processed multiple times.
    /// </remarks>
    [ UsedImplicitly ]
    public void ClearDomainEvents();
}
