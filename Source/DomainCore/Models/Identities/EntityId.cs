namespace Erdmier.DomainCore.Models.Identities;

/// <summary>Represents the id of an <see cref="Entity{TId}" />.</summary>
/// <typeparam name="TId">The underlying type of the id (e.g., <see cref="Guid" />).</typeparam>
public abstract class EntityId<TId> : ValueObject
{
    protected EntityId(TId value) => Value = value;

    protected EntityId()
    { }

    /// <summary>Gets the value of the id.</summary>
    public TId Value { get; } = default!;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    /// <inheritdoc />
    public override string? ToString() => Value?.ToString() ?? base.ToString();
}
