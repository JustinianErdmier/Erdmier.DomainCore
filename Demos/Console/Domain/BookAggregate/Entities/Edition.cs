using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects;
using Erdmier.DomainCore.Models;

namespace Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Entities;

public sealed class Edition : Entity<EditionId>
{
    private Edition(EditionId id, int year)
        : base(id) =>
        Year = year;

    private Edition()
    { }

    public int Year { get; }

    public static Edition Create(EditionId id, int year) => new(id, year);

    public static Edition CreateUnique(int year) => new(id: EditionId.CreateUnique(), year);
}
