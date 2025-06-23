namespace Erdmier.DomainCore;

/// <summary>Represents the ID of an <see cref="Entity{TId}" />.</summary>
/// <typeparam name="TId">The underlying type of the ID (e.g., <see cref="Guid" />).</typeparam>
public abstract class EntityId<TId> : ValueObject
{
    /// <summary>Instantiates a new <see cref="EntityId{TId}" />.</summary>
    /// <param name="value">The underlying value of the ID.</param>
    protected EntityId(TId value) => Value = value;

    // ReSharper disable once UnusedMember.Global
    /// <summary>Instantiates a new <see cref="EntityId{TId}" />.</summary>
    protected EntityId()
    { }

    // ReSharper disable once MemberCanBePrivate.Global
    /// <summary>Gets the value of the ID.</summary>
    public TId Value { get; } = default!;

    /// <inheritdoc />
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    /// <inheritdoc />
    public override string? ToString() => Value?.ToString() ?? base.ToString();
}
