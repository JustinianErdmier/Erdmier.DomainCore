namespace Demo.Core.Books.Responses;

public sealed record BookResponse(List<AuthorResponse> Authors, Guid Id, string Title)
{
    public static BookResponse Create(List<AuthorResponse> authors, Guid id, string title) => new(authors, id, title);

    public static BookResponse Create(Book book) => Create(book.Authors.Select(a => AuthorResponse.Create(a.Id.Value, a.Name)).ToList(), book.Id.Value, book.Title);

    public static List<BookResponse> Create(List<Book> books)
        => books.Select(b => Create(b.Authors.Select(a => AuthorResponse.Create(a.Id.Value, a.Name)).ToList(), b.Id.Value, b.Title))
                .ToList();
}
