namespace Erdmier.DomainCore.JsonSerializers;

public sealed class EntityJsonConverter<TId> : JsonConverter<Entity<TId>>
    where TId : ValueObject
{
    /// <inheritdoc />
    public override Entity<TId> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is JsonTokenType.Null or not JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // key is the property/parameter name; value is the parsed data.
        Dictionary<string, object?> parsedData = [];
        // key is the position in the creation method; value is the parsed data
        Dictionary<int, object?> arguments = [];

        Type derivedType = default!;

        // Parse properties from JSON
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = reader.GetString();

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new JsonException();
            }

            // Get value
            reader.Read();

            if (propertyName == "$type")
            {
                string derivedTypeName = reader.GetString() ?? throw new JsonException(message: "Unable to get the derived type name when parsing an entity");

                derivedType = Type.GetType(derivedTypeName) ??
                              throw new JsonException(message: $"Unable to get the derived type when parsing an entity using {derivedTypeName}");

                continue;
            }

            PropertyInfo[] properties = derivedType.GetProperties();

            PropertyInfo? property = properties.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));

            if (property is null)
            {
                throw new JsonException();
            }

            Type propertyType = property.PropertyType;

            // BUG: Issue with deserializing string. I guess `reader.ValueSpan` doesn't pass the quotation mark and the serializer says that the first letter of the string is invalid start token.
            object? value = JsonSerializer.Deserialize(reader.ValueSpan, propertyType, options);

            parsedData.Add(propertyName, value);
        }

        MethodInfo? createMethod = derivedType.GetMethod(name: "Create", bindingAttr: BindingFlags.Public | BindingFlags.Static);

        if (createMethod is null || createMethod.ReturnType != derivedType || createMethod.IsGenericMethod)
        {
            throw new JsonException(message: $"Unable to find a public, static, non-generic method named 'Create' that returns a {derivedType}");
        }

        // verify that the property arguments match the method signature in length and data types.
        ParameterInfo[] parameters = createMethod.GetParameters();

        if (parsedData.Count != parameters.Length)
        {
            throw new JsonException();
        }

        foreach (KeyValuePair<string, object?> data in parsedData)
        {
            ParameterInfo? parameter = parameters.FirstOrDefault(p => p.Name == data.Key);

            if (parameter is null || parameter.GetType() != data.Value?.GetType())
            {
                throw new JsonException();
            }

            arguments.Add(parameter.Position, data.Value);
        }

        return (Entity<TId>?)createMethod.Invoke(obj: null,
                                                 parameters: arguments.Order()
                                                                      .Select(a => a.Value)
                                                                      .ToArray()) ??
               throw new JsonException();
    }

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
            writer.WritePropertyName(propertyName: property.Name.ToLowerInvariant());
            JsonSerializer.Serialize(writer, value: property.GetValue(entity), options);
        }

        // End the JSON object
        writer.WriteEndObject();
    }
}
