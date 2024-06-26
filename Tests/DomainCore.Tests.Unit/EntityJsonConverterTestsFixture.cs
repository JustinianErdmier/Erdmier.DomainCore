using Erdmier.DomainCore.Tests.Unit.TestImplementations.Entities;

namespace Erdmier.DomainCore.Tests.Unit;

public sealed class EntityJsonConverterTestsFixture
{
    public TestEntity Entity { get; } = TestEntity.Create(name: "Justinian", age: 25);

    // public string EntityJson => $$"""{"$type":"{{typeof(TestEntity).AssemblyQualifiedName}}","""""
}
