namespace Demo.Core.Domain.BookAggregate.Events;

public sealed class BookTitleChangedEvent : IDomainEvent
{
    [ SetsRequiredMembers ]
    private BookTitleChangedEvent(BookId id, string oldTitle, string newTitle)
    {
        Id       = id;
        OldTitle = oldTitle;
        NewTitle = newTitle;
    }

    private BookTitleChangedEvent()
    { }

    public required BookId Id { get; init; }

    public required string OldTitle { get; init; }

    public required string NewTitle { get; init; }

    public static BookTitleChangedEvent Create(BookId id, string oldTitle, string newTitle) => new(id, oldTitle, newTitle);
}
