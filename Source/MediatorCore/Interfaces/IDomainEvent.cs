using Mediator;

namespace Erdmier.DomainCore.MediatorCore;

/// <summary>Represents a marker interface for domain events in a domain-driven design architecture.</summary>
/// <remarks>
///     Domain events are used to signal occurrences within a domain model that may require further processing or actions, such as notifying other parts of the system, triggering
///     workflows, or persisting changes. They implement Mediator's <see cref="INotification" /> interface to facilitate integration with the Mediator library's message dispatcher
///     mechanism.
/// </remarks>
public interface IDomainEvent : INotification
{ }
