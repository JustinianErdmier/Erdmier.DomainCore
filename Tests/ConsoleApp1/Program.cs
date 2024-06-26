using System.Text.Json;

using Erdmier.DomainCore.JsonSerializers;
using Erdmier.DomainCore.Tests.Unit.TestImplementations.Entities;

TestEntity entity = TestEntity.Create(name: "Justinian", age: 25);

JsonSerializerOptions serializerOptions =
    new(JsonSerializerDefaults.Web) { Converters = { new EntityIdJsonConverterFactory(), new EntityJsonConverterFactory() } };

string json = JsonSerializer.Serialize(entity, serializerOptions);

Console.WriteLine(json);

TestEntity? entity2 = JsonSerializer.Deserialize<TestEntity>(json, serializerOptions);

Console.WriteLine(entity2);
