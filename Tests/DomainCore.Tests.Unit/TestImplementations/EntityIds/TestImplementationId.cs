namespace Erdmier.DomainCore.Tests.Unit.TestImplementations.EntityIds;

public sealed class TestImplementationId : EntityId<Guid>
{
    private TestImplementationId(Guid value)
        : base(value)
    { }

    public static TestImplementationId Create(Guid? value = null) => new(value: value ?? Guid.NewGuid());
}
