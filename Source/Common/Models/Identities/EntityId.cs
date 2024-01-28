namespace Erdmier.DomainCore.Common.Models.Identities;

public abstract class EntityId<TId> : Value
{
    protected EntityId(TId value) => Value = value;

    protected EntityId()
    { }

    public TId Value { get; } = default!;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string? ToString() => Value?.ToString() ?? base.ToString();
}
