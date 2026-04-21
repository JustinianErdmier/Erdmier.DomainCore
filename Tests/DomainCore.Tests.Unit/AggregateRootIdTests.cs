using Erdmier.DomainCore.Tests.Models.Models.IDs;

using FluentAssertions;

namespace Erdmier.DomainCore.Tests.Unit;

public sealed class AggregateRootIdTests
{
    [ Fact ]
    public void Create_WithValidGuid_ShouldCreateInstance()
    {
        // Arrange
        Guid guid = Guid.NewGuid();

        // Act
        TestAggregateRootId id = TestAggregateRootId.Create(guid);

        // Assert
        id.Should().NotBeNull();
        id.Value.Should().Be(guid);
    }

    [ Fact ]
    public void Equals_WithSameValue_ShouldBeEqual()
    {
        // Arrange
        Guid                guid = Guid.NewGuid();
        TestAggregateRootId id1  = TestAggregateRootId.Create(guid);
        TestAggregateRootId id2  = TestAggregateRootId.Create(guid);

        // Act & Assert
        id1.Should().Be(id2);
        (id1 == id2).Should().BeTrue();
    }

    [ Fact ]
    public void Equals_WithDifferentValue_ShouldNotBeEqual()
    {
        // Arrange
        TestAggregateRootId id1 = TestAggregateRootId.Create();
        TestAggregateRootId id2 = TestAggregateRootId.Create();

        // Act & Assert
        id1.Should().NotBe(id2);
        (id1 != id2).Should().BeTrue();
    }

    [ Fact ]
    public void Value_ShouldReturnUnderlyingValue()
    {
        // Arrange
        Guid                guid = Guid.NewGuid();
        TestAggregateRootId id   = TestAggregateRootId.Create(guid);

        // Act
        Guid value = id.Value;

        // Assert
        value.Should().Be(guid);
    }

    [ Fact ]
    public void ToString_ShouldReturnStringRepresentation()
    {
        // Arrange
        Guid                guid = Guid.NewGuid();
        TestAggregateRootId id   = TestAggregateRootId.Create(guid);

        // Act
        string? result = id.ToString();

        // Assert
        result.Should().Be(guid.ToString());
    }
}
