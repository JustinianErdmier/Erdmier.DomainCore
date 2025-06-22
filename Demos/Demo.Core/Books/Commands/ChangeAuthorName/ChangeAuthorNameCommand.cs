namespace Demo.Core.Books.Commands.ChangeAuthorName;

public sealed record ChangeAuthorNameCommand(BookId BookId, AuthorId Id, string Name) : ICommand<bool>
{
    public static ChangeAuthorNameCommand Create(BookId bookId, AuthorId id, string name) => new(bookId, id, name);
}
