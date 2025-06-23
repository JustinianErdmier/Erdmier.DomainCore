using Erdmier.DomainCore.Tests.Models.Constants;
using Erdmier.DomainCore.Tests.Models.Models.SimpleValueObjects;

using FluentAssertions;

namespace Erdmier.DomainCore.Tests.Unit;

public class ValueObjectTests
{
    [ Fact ]
    public void Equals_ShouldCompareEqualityAsTrue_WhenGivenAnIdenticalObject()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber phoneNumber2 = Constants.ValueObjects.TestPhoneNumber1;

        // Act
        bool result = phoneNumber1.Equals(phoneNumber2);

        // Assert
        result.Should()
              .BeTrue();
    }

    [ Fact ]
    public void Equals_ShouldCompareEqualityAsFalse_WhenGivenADifferentObject()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber phoneNumber2 = Constants.ValueObjects.TestPhoneNumber2;

        // Act
        bool result = phoneNumber1.Equals(phoneNumber2);

        // Assert
        result.Should()
              .BeFalse();
    }

    [ Fact ]
    public void Equals_ShouldCompareEqualityAsFalse_WhenGivenNull()
    {
        // Arrange
        UnitedStatesPhoneNumber  phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber? phoneNumber2 = null;

        // Act
        bool result = phoneNumber1.Equals(phoneNumber2);

        // Assert
        result.Should()
              .BeFalse();
    }

    [ Fact ]
    public void Equals_ShouldCompareEqualityAsFalse_WhenGivenAnObjectOfADifferentType()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        object                  phoneNumber2 = "812-675-3057";

        // Act
        bool result = phoneNumber1.Equals(phoneNumber2);

        // Assert
        result.Should()
              .BeFalse();
    }

    [ Fact ]
    public void GetHashCode_ShouldReturnTheSameHashCode_WhenGivenTheSameObject()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber phoneNumber2 = Constants.ValueObjects.TestPhoneNumber1;

        // Act
        int result1 = phoneNumber1.GetHashCode();
        int result2 = phoneNumber2.GetHashCode();

        // Assert
        result1.Should()
               .Be(result2);
    }

    [ Fact ]
    public void GetHashCode_ShouldReturnDifferentHashCodes_WhenGivenDifferentObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber phoneNumber2 = Constants.ValueObjects.TestPhoneNumber2;

        // Act
        int result1 = phoneNumber1.GetHashCode();
        int result2 = phoneNumber2.GetHashCode();

        // Assert
        result1.Should()
               .NotBe(result2);
    }

    [ Fact ]
    public void GetHashCode_ShouldReturnAggregateHashCodeOfProperties_WhenDeclaredAsEqualityComponents()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber      = Constants.ValueObjects.TestPhoneNumber1;
        int                     expectedHashCode = phoneNumber.AreaCode.GetHashCode() ^ phoneNumber.LocalExchange.GetHashCode() ^ phoneNumber.SubscriberNumber.GetHashCode();

        // Act
        int result = phoneNumber.GetHashCode();

        // Assert
        result.Should()
              .Be(expectedHashCode);
    }

    [ Fact ]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenIdenticalObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber phoneNumber2 = Constants.ValueObjects.TestPhoneNumber1;

        // Act
        bool result = phoneNumber1 == phoneNumber2;

        // Assert
        result.Should()
              .BeTrue();
    }

    [ Fact ]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenDifferentObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber phoneNumber2 = Constants.ValueObjects.TestPhoneNumber2;

        // Act
        bool result = phoneNumber1 == phoneNumber2;

        // Assert
        result.Should()
              .BeFalse();
    }

    [ Fact ]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenNull()
    {
        // Arrange
        UnitedStatesPhoneNumber  phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber? phoneNumber2 = null;

        // Act
        bool result = phoneNumber1 == phoneNumber2!;

        // Assert
        result.Should()
              .BeFalse();
    }

    [ Fact ]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenDifferentObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber phoneNumber2 = Constants.ValueObjects.TestPhoneNumber2;

        // Act
        bool result = phoneNumber1 != phoneNumber2;

        // Assert
        result.Should()
              .BeTrue();
    }

    [ Fact ]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenTheSameObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber phoneNumber2 = Constants.ValueObjects.TestPhoneNumber1;

        // Act
        bool result = phoneNumber1 != phoneNumber2;

        // Assert
        result.Should()
              .BeFalse();
    }

    [ Fact ]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenNull()
    {
        // Arrange
        UnitedStatesPhoneNumber  phoneNumber1 = Constants.ValueObjects.TestPhoneNumber1;
        UnitedStatesPhoneNumber? phoneNumber2 = null;

        // Act
        bool result = phoneNumber1 != phoneNumber2!;

        // Assert
        result.Should()
              .BeTrue();
    }
}
