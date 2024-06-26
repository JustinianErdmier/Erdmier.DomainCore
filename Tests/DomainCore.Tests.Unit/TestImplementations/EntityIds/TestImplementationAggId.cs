namespace Erdmier.DomainCore.Tests.Unit.TestImplementations.EntityIds;

public sealed class TestImplementationAggId : AggregateRootId<Guid>
{
    private TestImplementationAggId(Guid value)
        : base(value)
    { }

    public static TestImplementationAggId Create(Guid? value = null) => new(value: value ?? Guid.NewGuid());
}
