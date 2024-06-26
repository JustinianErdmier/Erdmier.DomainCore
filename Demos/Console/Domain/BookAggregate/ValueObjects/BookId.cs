using Erdmier.DomainCore.Models.Identities;

namespace Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects;

public sealed class BookId : AggregateRootId<Guid>
{
    /// <inheritdoc />
    private BookId(Guid value)
        : base(value)
    { }

    public static BookId Create(Guid value) => new(value);

    public static BookId CreateUnique() => Create(value: Guid.NewGuid());
}
