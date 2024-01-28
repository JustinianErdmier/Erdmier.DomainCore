namespace Erdmier.DomainCore.Common.Models;

// TODO: Using source generation, add deconstruct method.
// TODO: Make value object serializable.

/// <summary>An immutable object.</summary>
public abstract class Value : IEquatable<Value>
{
    /// <inheritdoc />
    public bool Equals(Value? other) => Equals((object?)other);

    /// <summary>Gets a collection of values in a specified order that, when compared, will determine if two objects are equal.</summary>
    /// <remarks>It is the responsibility of the derived class to implement this method.</remarks>
    /// <returns>An <see cref="IEnumerable{T}" /> of nullable <see cref="object" />s.</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        Value value = (Value)obj;

        return GetEqualityComponents().SequenceEqual(value.GetEqualityComponents());
    }

    public new static bool Equals(object? objA, object? objB)
    {
        if (objA is null && objB is null)
            return true;

        if (objA is null || objB is null)
            return false;

        if (ReferenceEquals(objA, objB))
            return true;

        if (objA is not Value valueA || objB is not Value valueB)
            return false;

        return valueA.Equals(valueB);
    }

    /// <summary>Compares the equality of the given <paramref name="leftOperand" /> against the given <paramref name="rightOperand" />.</summary>
    /// <param name="leftOperand">The left operand. </param>
    /// <param name="rightOperand">The right operand.</param>
    /// <returns>A <see langword="bool" /> indicating the two operands are equal.</returns>
    public static bool operator ==(Value leftOperand, Value rightOperand) => Equals(leftOperand, rightOperand);

    /// <summary>Compares the inequality of the given <paramref name="leftOperand" /> against the given <paramref name="rightOperand" />.</summary>
    /// <param name="leftOperand">The left operand. </param>
    /// <param name="rightOperand">The right operand.</param>
    /// <returns>A <see langword="bool" /> indicating the two operands are not equal.</returns>
    public static bool operator !=(Value leftOperand, Value rightOperand) => !Equals(leftOperand, rightOperand);

    /// <inheritdoc />
    public override int GetHashCode() => GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
}

// [ Serializable ]
// public abstract class Value<T> : IEquatable<Value<T>>, ISerializable
// {
//     private readonly T? _value;
//
//     protected Value(T? value) => _value = value;
//
//     protected Value(SerializationInfo serializationInfo, StreamingContext streamingContext)
//     {
//         object? value = serializationInfo.GetValue(name: "values", typeof(T));
//         _value = value == default(object) ? default(T?) : (T)value;
//     }
//
//     /// <inheritdoc />
//     public bool Equals(Value<T>? other) => throw new NotImplementedException();
//
//     /// <inheritdoc />
//     public virtual void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext) =>
//         serializationInfo.AddValue(name: "values", _value);
//
//     /// <inheritdoc />
//     public override string ToString() => _value?.ToString() ?? string.Empty;
//
//     /// <inheritdoc />
//     public override bool Equals(object? obj)
//     {
//         if (obj is null || obj.GetType() != GetType())
//             return false;
//
//         if (ReferenceEquals(this, obj))
//             return true;
//
//         return obj is Value<T> other && Equals(_value, other._value);
//     }
//
//     /// <inheritdoc />
//     public override int GetHashCode() => (int)_value?.GetHashCode()!;
//
//     public static bool operator ==(Value<T>? leftOperand, Value<T>? rightOperand) => Equals(leftOperand, rightOperand);
//
//     public static bool operator !=(Value<T>? left, Value<T>? right) => !Equals(left, right);
// }
