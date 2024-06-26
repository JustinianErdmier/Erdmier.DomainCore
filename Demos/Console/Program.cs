using System.Text.Json;

using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate;
using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Entities;
using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Enums;
using Erdmier.DomainCore.JsonSerializers;

Author author = Author.CreateUnique(firstName: "Madeline", lastName: "Miller");

Book book = Book.CreateUnique(title: "The Song of Achilles", numberOfPages: 378, Genres.HistoricalFiction)
                .AddAuthor(author);

JsonSerializerOptions serializerOptions =
    new(JsonSerializerDefaults.Web) { Converters = { new EntityIdJsonConverterFactory(), new EntityJsonConverterFactory() }, WriteIndented = true };

string authorIdJson = JsonSerializer.Serialize(author.Id, serializerOptions);

Console.WriteLine(value: nameof(authorIdJson));
Console.WriteLine(value: authorIdJson + "\n");

string authorJson = JsonSerializer.Serialize(author, serializerOptions);

Console.WriteLine(value: nameof(authorJson));
Console.WriteLine(value: authorJson + "\n");

string bookIdJson = JsonSerializer.Serialize(book.Id, serializerOptions);

Console.WriteLine(value: nameof(bookIdJson));
Console.WriteLine(value: bookIdJson + "\n");

string bookJson = JsonSerializer.Serialize(book, serializerOptions);

Console.WriteLine(value: nameof(bookJson));
Console.WriteLine(value: bookJson + "\n");
