namespace Erdmier.DomainCore.Models;

// TODO: Using source generation, add deconstruct method.
// TODO: Make value object serializable.

/// <summary>An immutable object.</summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <inheritdoc />
    public bool Equals(ValueObject? other) => Equals(obj: other);

    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null
            || obj.GetType() != GetType())
        {
            return false;
        }

        ValueObject valueObject = (ValueObject)obj;

        return GetEqualityComponents()
            .SequenceEqual(valueObject.GetEqualityComponents());
    }

    /// <summary>Determines whether two <see cref="ValueObject" /> instances are equal.</summary>
    /// <param name="left">The first <see cref="ValueObject" /> to compare.</param>
    /// <param name="right">The second <see cref="ValueObject" /> to compare.</param>
    /// <returns><c>true</c> if the specified <see cref="ValueObject" /> instances are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(ValueObject left, ValueObject right) => Equals(left, right);

    /// <summary>Determines whether two <see cref="ValueObject" /> instances are not equal.</summary>
    /// <param name="left">The first <see cref="ValueObject" /> to compare.</param>
    /// <param name="right">The second <see cref="ValueObject" /> to compare.</param>
    /// <returns><c>true</c> if the specified <see cref="ValueObject" /> instances are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(ValueObject left, ValueObject right) => !Equals(left, right);

    /// <summary>Returns the hash code for the current <see cref="ValueObject" />.</summary>
    /// <returns>A hash code for the current <see cref="ValueObject" />.</returns>
    public override int GetHashCode()
        => GetEqualityComponents()
           .Select(x => x?.GetHashCode() ?? 0)
           .Aggregate((x, y) => x ^ y);
}
