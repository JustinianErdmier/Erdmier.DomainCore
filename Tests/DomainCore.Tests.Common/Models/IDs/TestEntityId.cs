namespace Erdmier.DomainCore.Tests.Models.Models.IDs;

public sealed class TestEntityId : EntityId<Guid>
{
    private TestEntityId(Guid value)
        : base(value)
    { }

    public static TestEntityId Create() => new(Guid.CreateVersion7());

    public static TestEntityId Create(Guid value) => new(value);
}
