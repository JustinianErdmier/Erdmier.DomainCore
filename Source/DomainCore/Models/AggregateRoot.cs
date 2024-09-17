namespace Erdmier.DomainCore.Models;

/// <summary>Represents the aggregate root in a domain-driven design context.</summary>
/// <typeparam name="TId">The type of the unique identifier for the aggregate root, which must derive from <see cref="AggregateRootId{TIdType}" />.</typeparam>
/// <typeparam name="TIdType">The underlying type of the unique identifier (e.g., <see cref="Guid" />).</typeparam>
public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRoot(TId id)
        : base(id)
        => Id = id;

    protected AggregateRoot()
    { }

    /// <summary>Gets the unique identifier of the aggregate root.</summary>
    /// <remarks>This property overrides the base <see cref="Entity{TId}.Id" /> property to ensure it is of type <see cref="AggregateRootId{TId}" />.</remarks>
    public new AggregateRootId<TIdType> Id
    {
        get => base.Id;

#pragma warning disable CA1061
        private init => base.Id = (TId)value;
#pragma warning restore CA1061
    }
}
