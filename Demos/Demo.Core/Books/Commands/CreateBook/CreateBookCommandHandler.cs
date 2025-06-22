namespace Demo.Core.Books.Commands.CreateBook;

public sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, BookId>
{
    private readonly AppDbContext _appContext;

    private readonly ILogger<CreateBookCommandHandler> _logger;

    public CreateBookCommandHandler(AppDbContext appContext, ILogger<CreateBookCommandHandler> logger)
    {
        _appContext = appContext;
        _logger     = logger;
    }

    public async ValueTask<BookId> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        Book book = Book.Create(CreateAuthors(command.AuthorNames), command.Title);

        _appContext.Books.Add(book);

        try
        {
            await _appContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, message: "Error while creating book {BookTitle}}", command.Title);

            throw;
        }

        _logger.LogInformation(message: "Book {BookTitle} has been created with ID `{BookId}`", command.Title, book.Id);

        return (BookId)book.Id;
    }

    private static List<Author> CreateAuthors(List<string> authorNames) => authorNames.Select(Author.Create).ToList();
}
