using Erdmier.DomainCore.Models;

namespace Erdmier.DomainCore.Tests.Unit.TestImplementations.Entities;

public sealed class TestEntity : Entity<TestImplementationId>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private TestEntity()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    { }

    private TestEntity(string name, int age, TestImplementationId id)
        : base(id)
    {
        Name = name;
        Age  = age;
    }


    public string Name { get; set; }

    public int Age { get; set; }

    public static TestEntity Create(string name, int age, TestImplementationId? id = null) => new(name, age, id: id ?? TestImplementationId.Create());
}
