namespace Erdmier.DomainCore.Tests.Models.Models.IDs;

public sealed class TestAggregateRootId : AggregateRootId<Guid>
{
    private TestAggregateRootId(Guid value)
        : base(value)
    { }

    public static TestAggregateRootId Create() => new(Guid.NewGuid());

    public static TestAggregateRootId Create(Guid value) => new(value);
}
