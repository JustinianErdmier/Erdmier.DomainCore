using Erdmier.DomainCore.Models.Identities;

namespace Erdmier.DomainCore.Mediator;

public abstract class AggregateRootWithDomainEvents<TId, TIdType> : EntityWithDomainEvents<TId>
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRootWithDomainEvents(TId id)
        : base(id)
        => Id = id;

    protected AggregateRootWithDomainEvents()
    { }

    public new AggregateRootId<TIdType> Id
    {
        get => base.Id;

#pragma warning disable CA1061
        private init => base.Id = (TId)value;
#pragma warning restore CA1061
    }
}
