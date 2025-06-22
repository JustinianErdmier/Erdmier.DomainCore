namespace Demo.Core.Domain.BookAggregate;

public sealed class Book : AggregateRootWithDomainEvents<BookId, Guid>
{
    private Book(Author author, string title, BookId? id = null)
        : base(id ?? BookId.Create())
    {
        Author = author;
        Title  = title;
    }

    private Book()
    { }

    public Author Author { get; private set; } = null!;

    public string Title { get; private set; } = null!;

    public void ChangeTitle(string newTitle)
    {
        BookTitleChangedEvent domainEvent = BookTitleChangedEvent.Create((BookId)Id, Title, newTitle);

        AddDomainEvent(domainEvent);

        Title = newTitle;
    }

    public void ChangeAuthor(Author newAuthor) => Author = newAuthor;

    public static Book Create(Author author, string title) => new(author, title);
}
