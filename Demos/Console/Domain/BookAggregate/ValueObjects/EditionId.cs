using Erdmier.DomainCore.Models.Identities;

namespace Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects;

public sealed class EditionId : EntityId<Guid>
{
    private EditionId(Guid value)
        : base(value)
    { }

    public static EditionId Create(Guid value) => new(value);

    public static EditionId CreateUnique() => new(value: Guid.NewGuid());
}
