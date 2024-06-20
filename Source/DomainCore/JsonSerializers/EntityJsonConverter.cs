namespace Erdmier.DomainCore.JsonSerializers;

public sealed class EntityJsonConverter<TId> : JsonConverter<Entity<TId>>
    where TId : ValueObject
{
    /// <inheritdoc />
    public override Entity<TId>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, Entity<TId> entity, JsonSerializerOptions options)
    {
        // Start creating a JSON object
        writer.WriteStartObject();

        // Write the type name, so it can be used during deserialization
        writer.WriteString(propertyName: "$type",
                           entity.GetType()
                                 .AssemblyQualifiedName);

        // Serialize all properties
        foreach (PropertyInfo property in entity.GetType()
                                                .GetProperties())
        {
            writer.WritePropertyName(property.Name);
            JsonSerializer.Serialize(writer, value: property.GetValue(entity), options);
        }

        // End the JSON object
        writer.WriteEndObject();
    }
}
