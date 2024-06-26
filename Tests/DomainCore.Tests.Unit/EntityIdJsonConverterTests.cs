namespace Erdmier.DomainCore.Tests.Unit;

public class EntityIdJsonConverterTests : IClassFixture<EntityIdJsonConverterTestsFixture>
{
    private readonly EntityIdJsonConverterTestsFixture _fixture;

    public EntityIdJsonConverterTests(EntityIdJsonConverterTestsFixture fixture) => _fixture = fixture;

    [ Fact ]
    public void SerializeEntityId_ShouldSucceed()
    {
        // Arrange
        string expected = _fixture.EntityIdJson;

        // Act
        string actual = JsonSerializer.Serialize(_fixture.EntityId, _fixture.SerializerOptions);

        // Assert
        actual.Should()
              .BeEquivalentTo(expected);
    }

    [ Fact ]
    public void DeserializeEntityId_ShouldSucceed()
    {
        // Arrange
        TestImplementationId expected = _fixture.EntityId;

        // Act
        TestImplementationId? actual = JsonSerializer.Deserialize<TestImplementationId>(_fixture.EntityIdJson, _fixture.SerializerOptions);

        // Assert
        actual.Should()
              .NotBeNull()
              .And.BeEquivalentTo(expected);
    }

    [ Fact ]
    public void SerializeAggregateRootId_ShouldSucceed()
    {
        // Arrange
        string expected = _fixture.AggregateRootIdJson;

        // Act
        string actual = JsonSerializer.Serialize(_fixture.AggregateRootId, _fixture.SerializerOptions);

        // Assert
        actual.Should()
              .BeEquivalentTo(expected);
    }

    [ Fact ]
    public void DeserializeAggregateRootId_ShouldSucceed()
    {
        // Arrange
        TestImplementationAggId expected = _fixture.AggregateRootId;

        // Act
        TestImplementationAggId? actual = JsonSerializer.Deserialize<TestImplementationAggId>(_fixture.AggregateRootIdJson, _fixture.SerializerOptions);

        // Assert
        actual.Should()
              .NotBeNull()
              .And.BeEquivalentTo(expected);
    }
}
