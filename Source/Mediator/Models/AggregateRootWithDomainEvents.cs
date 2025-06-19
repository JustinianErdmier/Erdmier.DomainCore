using Erdmier.DomainCore.Models.Identities;

using JetBrains.Annotations;

namespace Erdmier.DomainCore.Mediator;

/// <summary>Represents the root entity of an aggregate.</summary>
/// <typeparam name="TId">The type behind the ID of the aggregate root; must inherit from <see cref="AggregateRootId{TId}" />.</typeparam>
/// <typeparam name="TIdType">The underlying type defined in the <see cref="AggregateRootId{TId}" /> implementation.</typeparam>
/// <remarks><b>NOTE:</b> <typeparamref name="TId" /> must be an implementation of <see cref="AggregateRootId{TId}" />.</remarks>
public abstract class AggregateRootWithDomainEvents<TId, TIdType> : EntityWithDomainEvents<TId>
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRootWithDomainEvents(TId id)
        : base(id)
        => Id = id;

    protected AggregateRootWithDomainEvents()
    { }

    /// <summary>Gets the unique identifier of the aggregate root.</summary>
    /// <remarks>This property overrides the base <see cref="EntityWithDomainEvents{TId}.Id" /> property to ensure it is of type <see cref="AggregateRootId{TId}" />.</remarks>
    public new AggregateRootId<TIdType> Id
    {
        [ UsedImplicitly ] get => base.Id;

#pragma warning disable CA1061
        private init => base.Id = (TId)value;
#pragma warning restore CA1061
    }
}
