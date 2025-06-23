namespace Demo.Core.Books.Queries.GetAllBooks;

public sealed record GetAllBooksQuery : IQuery<List<Book>>
{
    public static GetAllBooksQuery Create() => new();
}
