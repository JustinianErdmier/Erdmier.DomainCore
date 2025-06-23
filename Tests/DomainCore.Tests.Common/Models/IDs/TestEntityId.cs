namespace Erdmier.DomainCore.Tests.Models.Models.IDs;

public sealed class TestEntityId : EntityId<Guid>
{
    private TestEntityId(Guid value)
        : base(value)
    { }

    private TestEntityId()
    { }

    public static TestEntityId Create() => new(Guid.NewGuid());

    public static TestEntityId Create(Guid value) => new(value);

    public static TestEntityId CreateDefault() => new();
}
