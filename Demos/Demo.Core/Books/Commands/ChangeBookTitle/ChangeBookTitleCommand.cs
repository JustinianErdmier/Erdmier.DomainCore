namespace Demo.Core.Books.Commands.ChangeBookTitle;

public sealed record ChangeBookTitleCommand(BookId Id, string Title) : ICommand<bool>
{
    public static ChangeBookTitleCommand Create(BookId id, string title) => new(id, title);
}
