namespace Erdmier.DomainCore.Models;

/// <summary>Represents the root entity of an aggregate.</summary>
/// <typeparam name="TId">The type behind the id of the aggregate root; must inherit from <see cref="AggregateRootId{TId}" />.</typeparam>
/// <typeparam name="TIdType">The type defined in <see cref="AggregateRootId{TId}" />. </typeparam>
public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRoot(TId id)
        : base(id) =>
        Id = id;

    protected AggregateRoot()
    { }

    /// <summary>Gets the <see cref="AggregateRootId{TId}" />.</summary>
    public new AggregateRootId<TIdType> Id
    {
        get => base.Id;

    #pragma warning disable CA1061
        private init => base.Id = (TId)value;
    #pragma warning restore CA1061
    }
}
