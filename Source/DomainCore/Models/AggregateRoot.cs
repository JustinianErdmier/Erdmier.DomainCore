namespace Erdmier.DomainCore.Models;

/// <summary>Represents the root entity of an aggregate.</summary>
/// <typeparam name="TId">The type behind the id of the aggregate root; must inherit from <see cref="AggregateRootId{TId}" />.</typeparam>
/// <typeparam name="TIdType">The underlying type defined in the <see cref="AggregateRootId{TId}" /> implementation.</typeparam>
public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRoot(TId id)
        : base(id) =>
        Id = id;

    protected AggregateRoot()
    { }

    /// <summary>Gets the unique identifier of the aggregate root.</summary>
    /// <remarks>This property overrides the base <see cref="Entity{TId}.Id" /> property to ensure it is of type <see cref="AggregateRootId{TId}" />.</remarks>
    public new AggregateRootId<TIdType> Id
    {
        // ReSharper disable once UnusedMember.Global
        get => base.Id;

    #pragma warning disable CA1061
        private init => base.Id = (TId)value;
    #pragma warning restore CA1061
    }
}
