using Erdmier.DomainCore.Common.Models.Identities;

namespace Erdmier.DomainCore.Common.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRoot(TId id) => Id = id;

    protected AggregateRoot()
    { }

    public new AggregateRootId<TIdType> Id { get; } = default!;
}
