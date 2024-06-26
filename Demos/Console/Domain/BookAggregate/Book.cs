using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Entities;
using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.Enums;
using Erdmier.DomainCore.Demos.Console.Domain.BookAggregate.ValueObjects;
using Erdmier.DomainCore.Models;

using Throw;

namespace Erdmier.DomainCore.Demos.Console.Domain.BookAggregate;

public sealed class Book : AggregateRoot<BookId, Guid>
{
    private readonly List<Author> _authors = [];

    private Book(BookId bookId, string title, int numberOfPages, Genres genre, List<Author> authors)
        : base(bookId)
    {
        UpdateTitle(title);
        SetNumberOfPages(NumberOfPages);
        SetGenre(genre);
        AddAuthors(authors);
    }

    private Book()
    { }

    public string Title { get; private set; } = default!;

    public int NumberOfPages { get; private set; }

    public Genres Genre { get; private set; }

    public IReadOnlyList<Author> Authors => _authors.AsReadOnly();

    public Book UpdateTitle(string title)
    {
        title.ThrowIfNull()
             .IfEmpty()
             .IfWhiteSpace();

        // Additional business logic/validation...

        Title = title;

        return this;
    }

    public Book SetNumberOfPages(int numberOfPages)
    {
        numberOfPages.Throw()
                     .IfNegative();

        // Additional business logic/validation...

        NumberOfPages = numberOfPages;

        return this;
    }

    public Book SetGenre(Genres genre)
    {
        genre.Throw()
             .IfOutOfRange();

        // Additional business logic/validation...

        Genre = genre;

        return this;
    }

    public Book AddAuthor(Author author)
    {
        if (!_authors.Contains(author))
        {
            _authors.Add(author);
        }

        return this;
    }

    public Book AddAuthors(List<Author> authors)
    {
        authors.ForEach(a => AddAuthor(a));

        return this;
    }

    public static Book Create(BookId bookId, string title, int numberOfPages, Genres genre, List<Author> authors) =>
        new(bookId, title, numberOfPages, genre, authors);

    public static Book CreateUnique(string title, int numberOfPages, Genres genre) =>
        Create(bookId: BookId.CreateUnique(), title, numberOfPages, genre, authors: []);
}
