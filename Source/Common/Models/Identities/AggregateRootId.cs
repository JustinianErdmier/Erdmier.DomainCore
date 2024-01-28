namespace Erdmier.DomainCore.Common.Models.Identities;

/// <summary>Represents the Id of an <see cref="AggregateRoot{TId,TIdType}" />.</summary>
/// <param name="value">The value of the aggregate root id.</param>
/// <typeparam name="TId">The type of <paramref name="value" />.</typeparam>
public abstract class AggregateRootId<TId>(TId value) : EntityId<TId>(value);
