namespace Erdmier.DomainCore.Models;

/// <summary>Represents a base entity in the domain model which can be uniquely identified by an ID of type <typeparamref name="TId" />.</summary>
/// <typeparam name="TId">The type of the unique identifier for this entity, which must derive from <see cref="ValueObject" />.</typeparam>
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : ValueObject
{
    protected Entity(TId id) => Id = id;

    protected Entity()
    { }

    /// <summary>Gets the unique identifier of the entity.</summary>
    public TId Id { get; protected init; } = default!;

    /// <summary>Determines whether the specified <see cref="Entity{TId}" /> is equal to the current <see cref="Entity{TId}" />.</summary>
    /// <param name="other">The <see cref="Entity{TId}" /> to compare with the current <see cref="Entity{TId}" />.</param>
    /// <returns><c>true</c> if the specified <see cref="Entity{TId}" /> is equal to the current <see cref="Entity{TId}" />; otherwise, <c>false</c>.</returns>
    public bool Equals(Entity<TId>? other) => Equals(obj: other);

    /// <summary>Determines whether the specified object is equal to the current <see cref="Entity{TId}" />.</summary>
    /// <param name="obj">The object to compare with the current <see cref="Entity{TId}" />.</param>
    /// <returns><c>true</c> if the specified object is equal to the current <see cref="Entity{TId}" />; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) => obj is Entity<TId> entity && Id.Equals(entity.Id);

    /// <summary>Compares two <see cref="Entity{TId}" /> objects to determine if they are equal.</summary>
    /// <param name="left">The first <see cref="Entity{TId}" /> to compare.</param>
    /// <param name="right">The second <see cref="Entity{TId}" /> to compare.</param>
    /// <returns><c>true</c> if both <see cref="Entity{TId}" /> objects are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);

    /// <summary>Compares two <see cref="Entity{TId}" /> objects to determine if they are not equal.</summary>
    /// <param name="left">The first <see cref="Entity{TId}" /> to compare.</param>
    /// <param name="right">The second <see cref="Entity{TId}" /> to compare.</param>
    /// <returns><c>true</c> if both <see cref="Entity{TId}" /> objects are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Entity<TId> left, Entity<TId> right) => !Equals(left, right);

    /// <summary>Returns the hash code for the current <see cref="Entity{TId}" />.</summary>
    /// <returns>A hash code for the current <see cref="Entity{TId}" />.</returns>
    public override int GetHashCode() => Id.GetHashCode();
}
