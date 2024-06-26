namespace Erdmier.DomainCore.JsonSerializers;

public sealed class EntityJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type? typeToConvert)
    {
        while (typeToConvert != null && typeToConvert != typeof(object))
        {
            Type currentType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;

            if (currentType == typeof(Entity<>))
            {
                return true;
            }

            typeToConvert = typeToConvert.BaseType;
        }

        return false;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        // Need to address issue with resolving ambiguous match for aggregate root id
        Type valueType = typeToConvert.GetProperty(name: "Id", bindingAttr: BindingFlags.Public | BindingFlags.Instance)
                                      ?.PropertyType ??
                         throw new JsonException();

        Type converterType = typeof(EntityJsonConverter<>).MakeGenericType(valueType);

        return (JsonConverter?)Activator.CreateInstance(converterType) ?? throw new JsonException();
    }
}
