using Erdmier.DomainCore.Models.Identities;

namespace Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects;

public sealed class AuthorId : EntityId<Guid>
{
    private AuthorId(Guid value)
        : base(value)
    { }

    public static AuthorId Create(Guid value) => new(value);

    public static AuthorId CreateUnique() => Create(value: Guid.NewGuid());
}
