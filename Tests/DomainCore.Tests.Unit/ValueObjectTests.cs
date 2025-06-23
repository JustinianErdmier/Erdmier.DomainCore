using Erdmier.DomainCore.Tests.Models.Models.SimpleValueObjects;

namespace Erdmier.DomainCore.Tests.Unit;

public class ValueObjectTests
{
    [ Fact ]
    public void Equals_ShouldCompareEqualityAsTrue_WhenGivenAnIdenticalObject()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber phoneNumber2 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");

        // Act
        bool actualResult = phoneNumber1.Equals(phoneNumber2);

        // Assert
        const bool expectedResult = true;
        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void Equals_ShouldCompareEqualityAsFalse_WhenGivenADifferentObject()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber phoneNumber2 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3058");

        // Act
        bool actualResult = phoneNumber1.Equals(phoneNumber2);

        // Assert
        const bool expectedResult = false;
        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void Equals_ShouldCompareEqualityAsFalse_WhenGivenNull()
    {
        // Arrange
        UnitedStatesPhoneNumber  phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber? phoneNumber2 = null!;

        // Act
        bool actualResult = phoneNumber1.Equals(phoneNumber2);

        // Assert
        const bool expectedResult = false;

        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void Equals_ShouldCompareEqualityAsFalse_WhenGivenAnObjectOfDifferentType()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        object                  phoneNumber2 = "812-675-3057";

        // Act
        bool actualResult = phoneNumber1.Equals(phoneNumber2);

        // Assert
        const bool expectedResult = false;

        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void GetHashCode_ShouldReturnTheSameHashCode_WhenGivenTheSameObject()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber phoneNumber2 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");

        // Act
        int actualResult   = phoneNumber1.GetHashCode();
        int expectedResult = phoneNumber2.GetHashCode();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void GetHashCode_ShouldReturnDifferentHashCodes_WhenGivenDifferentObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber phoneNumber2 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3058");

        // Act
        int actualResult1 = phoneNumber1.GetHashCode();
        int actualResult2 = phoneNumber2.GetHashCode();

        // Assert
        Assert.NotEqual(actualResult1, actualResult2);
    }

    [ Fact ]
    public void EqualityOperator_ShouldReturnTrue_WhenGivenIdenticalObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber phoneNumber2 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");

        // Act
        bool actualResult = phoneNumber1 == phoneNumber2;

        // Assert
        const bool expectedResult = true;
        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenDifferentObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber phoneNumber2 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3058");

        // Act
        bool actualResult = phoneNumber1 == phoneNumber2;

        // Assert
        const bool expectedResult = false;
        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void EqualityOperator_ShouldReturnFalse_WhenGivenNull()
    {
        // Arrange
        UnitedStatesPhoneNumber  phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber? phoneNumber2 = null!;

        // Act
        bool actualResult = phoneNumber1 == phoneNumber2;

        // Assert
        const bool expectedResult = false;
        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenDifferentObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber phoneNumber2 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3058");

        // Act
        bool actualResult = phoneNumber1 != phoneNumber2;

        // Assert
        const bool expectedResult = true;
        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void InequalityOperator_ShouldReturnFalse_WhenGivenTheSameObjects()
    {
        // Arrange
        UnitedStatesPhoneNumber phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber phoneNumber2 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");

        // Act
        bool actualResult = phoneNumber1 != phoneNumber2;

        // Assert
        const bool expectedResult = false;
        Assert.Equal(expectedResult, actualResult);
    }

    [ Fact ]
    public void InequalityOperator_ShouldReturnTrue_WhenGivenNull()
    {
        // Arrange
        UnitedStatesPhoneNumber  phoneNumber1 = new(areaCode: "812", localExchange: "675", subscriberNumber: "3057");
        UnitedStatesPhoneNumber? phoneNumber2 = null!;

        // Act
        bool actualResult = phoneNumber1 != phoneNumber2;

        // Assert
        const bool expectedResult = true;

        Assert.Equal(expectedResult, actualResult);
    }
}
