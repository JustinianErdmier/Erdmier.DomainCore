namespace Demo.Core.Domain.BookAggregate;

public sealed class Book : AggregateRootWithDomainEvents<BookId, Guid>
{
    private readonly List<Author> _authors = [];

    private Book(List<Author> authors, string title, BookId? id = null)
        : base(id ?? BookId.Create())
    {
        _authors = authors;
        Title    = title;
    }

    private Book()
    { }

    public IReadOnlyList<Author> Authors => _authors.AsReadOnly();

    public string Title { get; private set; } = null!;

    public void ChangeTitle(string newTitle)
    {
        BookTitleChangedEvent domainEvent = BookTitleChangedEvent.Create((BookId)Id, Title, newTitle);

        AddDomainEvent(domainEvent);

        Title = newTitle;
    }

    public bool AddAuthor(Author author)
    {
        if (_authors.Contains(author))
        {
            return false;
        }

        _authors.Add(author);

        return true;
    }

    public static Book Create(List<Author> authors, string title) => new(authors, title);
}
