using JetBrains.Annotations;

namespace Erdmier.DomainCore.Mediator;

public interface IHasDomainEvents
{
    [ UsedImplicitly ]
    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    [ UsedImplicitly ]
    public void ClearDomainEvents();
}
