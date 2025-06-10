using Erdmier.DomainCore.Models.Identities;

namespace Erdmier.DomainCore.Tests.Models.IDs;

public sealed class BookId : EntityId<Guid>
{
    private BookId(Guid value)
        : base(value)
    { }

    public static BookId Create() => new(Guid.CreateVersion7());

    public static BookId Create(Guid value) => new(value);
}
