using Erdmier.DomainCore.Tests.Models.Constants;
using Erdmier.DomainCore.Tests.Models.Models.IDs;

using FluentAssertions;

namespace Erdmier.DomainCore.Tests.Unit;

public sealed class EntityIdTests
{
    [ Fact ]
    public void Constructor_ShouldSetValue_WhenGivenAValue()
    {
        // Arrange
        Guid expectedValue = Guid.NewGuid();

        // Act
        TestEntityId id          = TestEntityId.Create(expectedValue);
        Guid         actualValue = id.Value;

        // Assert
        actualValue.Should()
                   .Be(expectedValue);
    }

    [ Fact ]
    public void DefaultConstructor_ShouldSetValueToDefault_WhenCalled()
    {
        // Arrange
        TestEntityId id            = TestEntityId.CreateDefault();
        Guid         expectedValue = Guid.Empty;

        // Act
        Guid actualValue = id.Value;

        // Assert
        actualValue.Should()
                   .Be(expectedValue);
    }

    [ Fact ]
    public void Equals_ShouldReturnTrue_ForSameValues()
    {
        // Arrange
        TestEntityId id1 = Constants.EntityIds.Id1;
        TestEntityId id2 = Constants.EntityIds.Id1;

        // Act
        bool result = id1.Equals(id2);

        // Assert
        result.Should()
              .BeTrue();
    }

    [ Fact ]
    public void Equals_ShouldReturnFalse_ForDifferentValues()
    {
        // Arrange
        TestEntityId id1 = Constants.EntityIds.Id1;
        TestEntityId id2 = Constants.EntityIds.Id2;

        // Act
        bool result = id1.Equals(id2);

        // Assert
        result.Should()
              .BeFalse();
    }

    [ Fact ]
    public void GetHashCode_ShouldBeSame_ForSameValues()
    {
        // Arrange
        Guid         value = Guid.NewGuid();
        TestEntityId id1   = Constants.EntityIds.Id1;
        TestEntityId id2   = Constants.EntityIds.Id1;

        // Act
        int result1 = id1.GetHashCode();
        int result2 = id2.GetHashCode();

        // Assert
        result1.Should()
               .Be(result2);
    }

    [ Fact ]
    public void GetHashCode_ShouldBeDifferent_ForDifferentValues()
    {
        // Arrange
        TestEntityId id1 = Constants.EntityIds.Id1;
        TestEntityId id2 = Constants.EntityIds.Id2;

        // Act
        int result1 = id1.GetHashCode();
        int result2 = id2.GetHashCode();

        // Assert
        result1.Should()
               .NotBe(result2);
    }

    [ Fact ]
    public void GetHashCode_ShouldReturnHashcodeOfValue_WhenCalled()
    {
        // Arrange
        TestEntityId id               = Constants.EntityIds.Id1;
        int          expectedHashCode = id.Value.GetHashCode();

        // Act
        int result = id.GetHashCode();

        // Assert

        result.Should()
              .Be(expectedHashCode);
    }

    [ Fact ]
    public void ToString_ShouldReturnValueAsString()
    {
        // Arrange
        Guid         value = Guid.NewGuid();
        TestEntityId id    = TestEntityId.Create(value);

        // Act
        string? actualValue = id.ToString();

        // Assert
        string expectedValue = value.ToString();

        actualValue.Should()
                   .Be(expectedValue);
    }
}
