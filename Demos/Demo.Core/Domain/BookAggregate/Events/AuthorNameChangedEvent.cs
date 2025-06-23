namespace Demo.Core.Domain.BookAggregate.Events;

public sealed class AuthorNameChangedEvent : IDomainEvent
{
    [ SetsRequiredMembers ]
    private AuthorNameChangedEvent(AuthorId id, string oldName, string newName)
    {
        Id      = id;
        OldName = oldName;
        NewName = newName;
    }

    public required AuthorId Id { get; init; }

    public required string OldName { get; init; }

    public required string NewName { get; init; }

    public static AuthorNameChangedEvent Create(AuthorId id, string oldName, string newName) => new(id, oldName, newName);
}
