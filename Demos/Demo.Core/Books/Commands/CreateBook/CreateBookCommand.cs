namespace Demo.Core.Books.Commands.CreateBook;

public sealed record CreateBookCommand(List<string> AuthorNames, string Title) : ICommand<BookId>
{
    public static CreateBookCommand Create(List<string> authorNames, string title) => new(authorNames, title);
}
