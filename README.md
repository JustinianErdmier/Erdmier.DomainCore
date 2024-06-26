# The Goal Behind Erdmier.DomainCore

## Inspiration & Purpose
This package is a simple collection of base classes for designing and implementing domain aggregates and entities. The `ValueObject`, `EntityId`, `AggregateRootId`, `Entity`, and `AggregateRoot` classes are all based on those designed by Amichai Mantinband in his [YouTube DDD series](https://youtube.com/playlist?list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k&si=H_Aj_i7wusL1iIoo). There are some differences in my classes that make them more compatible with EF Core. The purpose of this package is to create a single library for these classes and relevant features (e.g., serialization) that can be published to NuGet and reused across my and others apps.

## The Current Issue
The biggest issue I am facing right now is that this design does not work well with JSON serialization and deserialization. Before creating this package, I attempted to follow the steps provided in the documentation regarding polymorhpic serialization. However, it quickly became a huge mess and still wouldn't entirely work. So the primary concern right now is to get serialization and deserialization to work but also with little to no additional code written by the consumer (no annotations or custom classes).

One of, but not the sole reason as to why the built-in polymorphic serializer won't work is because of the intentional design behind the access of the constructors and the intended way to create new objects. All constructors should be private and a static method named `Create` be used instead. As of right now, the `Create`

### Tests & Demos
I did start to write unit tests, and do plan to write many more, but decided to take a different approach because my IDE is currently having an issue with debugging unit tests. So I created a console demo app (`Erdmier.DomainCore.Demos.Console`) where I've defined some dummy domain types and am serializing/deserializing them.

### Serializing
I was able to get the serialization for types deriving from the `EntityId`, `AggregateRootId`, and `Entity` classes but am running into an issue when trying to serialize a type deriving from `AggregateRoot`. When trying to serialize the `Book` aggregate root, for example, the `EntityJsonConverterFactory.CreateConverter()` method throws the following error:

```text
Unhandled exception. System.Reflection.AmbiguousMatchException: Ambiguous match found for 'Erdmier.DomainCore.Models.AggregateRoot`2[Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects.BookId,System.Guid] Erdmier.DomainCore.Models.Identities.AggregateRootId`1[System.Guid] Id'.
   at System.RuntimeType.GetPropertyImpl(String name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
   at System.Type.GetProperty(String name, BindingFlags bindingAttr)
   at Erdmier.DomainCore.JsonSerializers.EntityJsonConverterFactory.CreateConverter(Type typeToConvert, JsonSerializerOptions options) in C:\Users\justi\Source\Personal\Erdmier.DomainCore\Source\DomainCore\JsonSerializers\EntityJsonConverterFactory.cs:line 31 
   at System.Text.Json.Serialization.JsonConverterFactory.GetConverterInternal(Type typeToConvert, JsonSerializerOptions options)
   at System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver.GetConverterForType(Type typeToConvert, JsonSerializerOptions options, Boolean resolveJsonConverterAttribute)
   at System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver.GetTypeInfo(Type type, JsonSerializerOptions options)
   at System.Text.Json.JsonSerializerOptions.GetTypeInfoNoCaching(Type type)
   at System.Text.Json.JsonSerializerOptions.CachingContext.CreateCacheEntry(Type type, CachingContext context)
--- End of stack trace from previous location ---
   at System.Text.Json.JsonSerializerOptions.GetTypeInfoInternal(Type type, Boolean ensureConfigured, Nullable`1 ensureNotNull, Boolean resolveIfMutable, Boolean fallBackToNearestAncestorType)
   at System.Text.Json.JsonSerializerOptions.GetTypeInfoForRootType(Type type, Boolean fallBackToNearestAncestorType)
   at System.Text.Json.JsonSerializer.GetTypeInfo[T](JsonSerializerOptions options)
   at System.Text.Json.JsonSerializer.Serialize[TValue](TValue value, JsonSerializerOptions options)
   at Program.<Main>$(String[] args) in C:\Users\justi\Source\Personal\Erdmier.DomainCore\Demos\Console\Program.cs:line 31
```

I used the debugger to step through the `GetProperty()` method, and was able to find that the issue is that the following two properties are found:

```text
+-+----------+-------+--------+----------------------+--------------------------------------------------------------------------------------------------------------------------------+----------------------------------------------------------------------------------+-------------+-------------+----------+-------------+--------------+----+-------------------------------------------------------------------------+----------------------------------------------------------+--------------------------------------------------------------------------------------+
|#|Attributes|CanRead|CanWrite|CustomAttributes      |DeclaringType                                                                                                                   |GetMethod                                                                         |IsCollectible|IsSpecialName|MemberType|MetadataToken|Module        |Name|PropertyType                                                             |ReflectedType                                             |SetMethod                                                                             |
+-+----------+-------+--------+----------------------+--------------------------------------------------------------------------------------------------------------------------------+----------------------------------------------------------------------------------+-------------+-------------+----------+-------------+--------------+----+-------------------------------------------------------------------------+----------------------------------------------------------+--------------------------------------------------------------------------------------+
|0|None      |true   |false   |CustomAttributeData[0]|Erdmier.DomainCore.Models.AggregateRoot`2[Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects.BookId,System.Guid]|Erdmier.DomainCore.Models.Identities.AggregateRootId`1[System.Guid] get_Id()      |false        |false        |Property  |385875969    |DomainCore.dll|Id  |Erdmier.DomainCore.Models.Identities.AggregateRootId`1[System.Guid]      |Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Book|null                                                                                  |
|1|None      |true   |true    |CustomAttributeData[0]|Erdmier.DomainCore.Models.Entity`1[Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects.BookId]                   |Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects.BookId get_Id()|false        |false        |Property  |385875970    |DomainCore.dll|Id  |Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects.BookId|Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Book|Void set_Id(Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects.BookId)|
+-+----------+-------+--------+----------------------+--------------------------------------------------------------------------------------------------------------------------------+----------------------------------------------------------------------------------+-------------+-------------+----------+-------------+--------------+----+-------------------------------------------------------------------------+----------------------------------------------------------+--------------------------------------------------------------------------------------+
```

I'm not really sure what to do here. The intended serialization of the class's properties is the same for both types derived from `Entity` and `AggregateRoot`; creating an entirely new factory and converter class for types deriving from `AggregateRoot` seems overkill and I'd like to avoid it. Instead, if it's possible, we need to identify if the derived type is that of `AggregateRoot` and handle appropriately.

### Deserialization
Deserializing types derived from `EntityId` and `AggregateRootId` works as currently expected. I say "currently expected" because I'm not entirely sure if anything will break/change.

I'm sure there's a cleaner and/or more sophisticated way to write the logic of the `EntityJsonConverter.Read()` method, but I haven't gotten there yet and have more focused on the MVP (i.e., just getting it working) first. The simple idea is to parse each of the JSON properties based on derived type's definition. Immediately, you might note the difference between how I'm ready the data in the `EntityJsonConverter` versus `EntityIdJsonConverter`. The logic in `EntityIdJsonConverter`, using the `JsonDocument` object, was generated by ChatGPT and modified by me. The use of the `while` loop is what is used in the documentation examples for creating custom converters.

Apart from basic validation, we want to be able to parse the properties of derived types agnostic to their types. However, the only thing I have found to even remotely work like this is to pass `reader.ValueSpan` to the `JsonSerializer.Deserialize()` method. However, this is throwing an error when trying to parse the value for a property of type string (e.g., `Author.FirstName`). For example, in the console demo, the the dummy author object is instantiated with the `FirstName` set to "Madeline", and trying to deserialize the author throws the following error:

```text
Unhandled exception. System.Text.Json.JsonException: 'M' is an invalid start of a value. Path: $ | LineNumber: 0 | BytePositionInLine: 0.
 ---> System.Text.Json.JsonReaderException: 'M' is an invalid start of a value. LineNumber: 0 | BytePositionInLine: 0.
   at System.Text.Json.ThrowHelper.ThrowJsonReaderException(Utf8JsonReader& json, ExceptionResource resource, Byte nextByte, ReadOnlySpan`1 bytes)
   at System.Text.Json.Utf8JsonReader.ConsumeValue(Byte marker)
   at System.Text.Json.Utf8JsonReader.ReadFirstToken(Byte first)
   at System.Text.Json.Utf8JsonReader.ReadSingleSegment()
   at System.Text.Json.Utf8JsonReader.Read()
   at System.Text.Json.Serialization.JsonConverter`1.ReadCore(Utf8JsonReader& reader, JsonSerializerOptions options, ReadStack& state)
   --- End of inner exception stack trace ---
   at System.Text.Json.ThrowHelper.ReThrowWithPath(ReadStack& state, JsonReaderException ex)
   at System.Text.Json.Serialization.JsonConverter`1.ReadCore(Utf8JsonReader& reader, JsonSerializerOptions options, ReadStack& state)
   at System.Text.Json.Serialization.Metadata.JsonTypeInfo`1.DeserializeAsObject(Utf8JsonReader& reader, ReadStack& state)
   at System.Text.Json.JsonSerializer.ReadFromSpanAsObject(ReadOnlySpan`1 utf8Json, JsonTypeInfo jsonTypeInfo, Nullable`1 actualByteCount)
   at System.Text.Json.JsonSerializer.Deserialize(ReadOnlySpan`1 utf8Json, Type returnType, JsonSerializerOptions options)
   at Erdmier.DomainCore.JsonSerializers.EntityJsonConverter`1.Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options) in C:\Users\justi\Source\Personal\Erdmier.DomainCore\Source\DomainCore\JsonSerializers\EntityJsonConverter.cs:line 66
   at System.Text.Json.Serialization.JsonConverter`1.ReadAsObject(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)
   at System.Text.Json.Serialization.Converters.CastingConverter`1.Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)
   at System.Text.Json.Serialization.JsonConverter`1.TryRead(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options, ReadStack& state, T& value, Boolean& isPopulatedValue)
   at System.Text.Json.Serialization.JsonConverter`1.ReadCore(Utf8JsonReader& reader, JsonSerializerOptions options, ReadStack& state)
   at System.Text.Json.JsonSerializer.ReadFromSpan[TValue](ReadOnlySpan`1 utf8Json, JsonTypeInfo`1 jsonTypeInfo, Nullable`1 actualByteCount)
   at System.Text.Json.JsonSerializer.ReadFromSpan[TValue](ReadOnlySpan`1 json, JsonTypeInfo`1 jsonTypeInfo)
   at System.Text.Json.JsonSerializer.Deserialize[TValue](String json, JsonSerializerOptions options)
   at Program.<Main>$(String[] args) in C:\Users\justi\Source\Personal\Erdmier.DomainCore\Demos\Console\Program.cs:line 44
```

This issue has particularly stumped me. The only "solution" I can think of would be to manually check the type of the value and write a `switch` statement (or series of `if` statements) calling the appropriate method on the `Utf8JsonReader` object (e.g., `reader.GetString()`, `reader.GetInt()`, etc.). However, this is not sustainable nor is it desidesirable.
