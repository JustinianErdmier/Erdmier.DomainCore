using System.Text.Json;

using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate;
using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Entities;
using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Enums;
using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects;
using Erdmier.DomainCore.JsonSerializers;


#region Variables

AuthorId authorId = AuthorId.CreateUnique();

Author author = Author.Create(authorId, firstName: "Madeline", lastName: "Miller");

BookId bookId = BookId.CreateUnique();

Book book = Book.Create(bookId, title: "The Song of Achilles", numberOfPages: 378, Genres.HistoricalFiction, authors: [])
                .AddAuthor(author);

JsonSerializerOptions serializerOptions =
    new(JsonSerializerDefaults.Web) { Converters = { new EntityIdJsonConverterFactory(), new EntityJsonConverterFactory() }, WriteIndented = true };

#endregion


#region Serializations & Deserializations

string authorIdJson = JsonSerializer.Serialize(authorId, serializerOptions);

Console.WriteLine(value: nameof(authorIdJson));
Console.WriteLine(value: authorIdJson + "\n");

AuthorId? authorIdFromJson = JsonSerializer.Deserialize<AuthorId>(authorIdJson, serializerOptions);

Console.WriteLine(value: nameof(authorIdFromJson));
Console.WriteLine(value: authorIdFromJson + "\n");

string authorJson = JsonSerializer.Serialize(author, serializerOptions);

Console.WriteLine(value: nameof(authorJson));
Console.WriteLine(value: authorJson + "\n");

Author? authorFromJson = JsonSerializer.Deserialize<Author>(authorJson, serializerOptions);

Console.WriteLine(value: nameof(authorFromJson));
Console.WriteLine(value: authorFromJson + "\n");

string bookIdJson = JsonSerializer.Serialize(bookId, serializerOptions);

Console.WriteLine(value: nameof(bookIdJson));
Console.WriteLine(value: bookIdJson + "\n");

BookId? bookIdFromJson = JsonSerializer.Deserialize<BookId>(bookIdJson, serializerOptions);

Console.WriteLine(value: nameof(bookIdFromJson));
Console.WriteLine(value: bookIdFromJson + "\n");

// string bookJson = JsonSerializer.Serialize(book, serializerOptions);
//
// Console.WriteLine(value: nameof(bookJson));
// Console.WriteLine(value: bookJson + "\n");
//
// Book? bookFromJson = JsonSerializer.Deserialize<Book>(bookJson, serializerOptions);
//
// Console.WriteLine(nameof(bookFromJson));
// Console.WriteLine(bookFromJson + "\n");

#endregion
