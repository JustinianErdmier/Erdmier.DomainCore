namespace Erdmier.DomainCore.Models.Identities;

/// <summary>Represents an id of an <see cref="AggregateRoot{TId,TIdType}" />.</summary>
/// <typeparam name="TId">The underlying type of the id (e.g., <see cref="Guid" />).</typeparam>
public abstract class AggregateRootId<TId> : EntityId<TId>
{
    protected AggregateRootId(TId value)
        : base(value)
    { }
}
