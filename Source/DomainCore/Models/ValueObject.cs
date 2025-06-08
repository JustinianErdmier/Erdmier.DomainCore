namespace Erdmier.DomainCore.Models;

/// <summary>An immutable object.</summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>Determines whether the specified <see cref="ValueObject" /> is equal to the current <see cref="ValueObject" />.</summary>
    /// <param name="other">The <see cref="ValueObject" /> to compare with the current <see cref="ValueObject" />.</param>
    /// <returns><c>TRUE</c> if the specified <see cref="ValueObject" /> is equal to the current <see cref="ValueObject" />; otherwise, <c>FALSE</c>.</returns>
    public bool Equals(ValueObject? other) => Equals(obj: other);

    /// <summary>Gets the specified members of the <see cref="ValueObject" /> to use when making equality comparisons.</summary>
    /// <returns>An <see cref="IEnumerable{T}" /> of the values of the specified members.</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <summary>Determines whether the specified <see cref="Object" /> is equal to the current <see cref="ValueObject" />.</summary>
    /// <param name="obj">The <see cref="Object" /> to compare with the current <see cref="ValueObject" />.</param>
    /// <returns><c>TRUE</c> if the specified <see cref="Object" /> is equal to the current <see cref="ValueObject" />; otherwise, <c>FALSE</c>.</returns>
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
    /// <returns><c>TRUE</c> if both <see cref="ValueObject" /> instances are equal; otherwise, <c>FALSE</c>.</returns>
    public static bool operator ==(ValueObject left, ValueObject right) => Equals(left, right);

    /// <summary>Determines whether two <see cref="ValueObject" /> instances are <i>not</i> equal.</summary>
    /// <param name="left">The first <see cref="ValueObject" /> to compare.</param>
    /// <param name="right">The second <see cref="ValueObject" /> to compare.</param>
    /// <returns><c>TRUE</c> if both <see cref="ValueObject" /> instances are <i>not</i> equal; otherwise, <c>FALSE</c>.</returns>
    public static bool operator !=(ValueObject left, ValueObject right) => !Equals(left, right);

    /// <summary>Returns the hash code for the current <see cref="ValueObject" />.</summary>
    /// <returns>A hash code for the current <see cref="ValueObject" />.</returns>
    public override int GetHashCode()
        => GetEqualityComponents()
           .Select(x => x?.GetHashCode() ?? 0)
           .Aggregate((x, y) => x ^ y);
}
