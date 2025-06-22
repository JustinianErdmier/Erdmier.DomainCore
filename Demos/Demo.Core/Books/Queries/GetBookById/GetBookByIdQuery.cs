namespace Demo.Core.Books.Queries.GetBookById;

public sealed record GetBookByIdQuery(BookId Id) : IQuery<Book?>
{
    public static GetBookByIdQuery Create(BookId id) => new(id);
}
