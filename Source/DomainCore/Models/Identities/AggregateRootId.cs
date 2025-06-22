namespace Erdmier.DomainCore;

/// <summary>Represents an ID of an <see cref="AggregateRoot{TId,TIdType}" />.</summary>
/// <typeparam name="TIdType">The underlying type of the ID (e.g., <see cref="Guid" />).</typeparam>
public abstract class AggregateRootId<TIdType> : EntityId<TIdType>
{
    /// <summary>Instantiates a new <see cref="AggregateRootId{TIdType}" />.</summary>
    /// <param name="value">The underlying value of the ID.</param>
    protected AggregateRootId(TIdType value)
        : base(value)
    { }
}
