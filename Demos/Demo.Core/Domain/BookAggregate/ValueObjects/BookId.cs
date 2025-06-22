using Erdmier.DomainCore.Models.Identities;

namespace Demo.Core.Domain.BookAggregate.ValueObjects;

public sealed class BookId : AggregateRootId<Guid>
{
    private BookId(Guid value)
        : base(value)
    { }

    public static BookId Create() => new(Guid.CreateVersion7());

    public static BookId Create(Guid value) => new(value);
}
