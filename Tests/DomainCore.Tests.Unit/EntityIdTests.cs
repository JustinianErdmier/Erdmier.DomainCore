using Erdmier.DomainCore.Tests.Models.Models.IDs;

namespace Erdmier.DomainCore.Tests.Unit;

public sealed class EntityIdTests
{
    [ Fact ]
    public void Constructor_ShouldSetValue_WhenGivenAValue()
    {
        // Arrange
        Guid expectedValue = Guid.CreateVersion7();

        // Act
        TestEntityId testEntityId = TestEntityId.Create(expectedValue);
        Guid         actualValue  = testEntityId.Value;

        // Assert
        Assert.Equal(expectedValue, actualValue);
    }

    [ Fact ]
    public void ToString_ReturnsValueAsString()
    {
        // Arrange
        Guid         value        = Guid.NewGuid();
        TestEntityId testEntityId = TestEntityId.Create(value);

        // Act
        string? actualValue = testEntityId.ToString();

        // Assert
        string expectedValue = value.ToString();

        Assert.Equal(expectedValue, actualValue);
    }
}
