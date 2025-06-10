using Erdmier.DomainCore.Tests.Models.IDs;

namespace Erdmier.DomainCore.Tests.Unit;

public sealed class EntityIdTests
{
    [ Fact ]
    public void Constructor_ShouldSetValue_WhenGivenAValue()
    {
        // Arrange
        Guid expectedValue = Guid.CreateVersion7();

        // Act
        BookId bookId      = BookId.Create(expectedValue);
        Guid   actualValue = bookId.Value;

        // Assert
        Assert.Equal(expectedValue, actualValue);
    }

    [ Fact ]
    public void ToString_ReturnsValueAsString()
    {
        // Arrange
        Guid   value  = Guid.NewGuid();
        BookId bookId = BookId.Create(value);

        // Act
        string? actualValue = bookId.ToString();

        // Assert
        string expectedValue = value.ToString();

        Assert.Equal(expectedValue, actualValue);
    }
}
