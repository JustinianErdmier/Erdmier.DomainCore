namespace Erdmier.DomainCore.Tests.Unit;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class EntityIdJsonConverterTestsFixture
{
    public TestImplementationId EntityId { get; } = TestImplementationId.Create();

    public string EntityIdJson => $$"""{"$type":"{{typeof(TestImplementationId).AssemblyQualifiedName}}","value":"{{EntityId}}"}""";

    public TestImplementationAggId AggregateRootId { get; } = TestImplementationAggId.Create();

    public string AggregateRootIdJson => $$"""{"$type":"{{typeof(TestImplementationAggId).AssemblyQualifiedName}}","value":"{{AggregateRootId}}"}""";

    public JsonSerializerOptions SerializerOptions { get; } = new(JsonSerializerDefaults.Web) { Converters = { new EntityIdJsonConverterFactory() } };
}
