namespace Demo.Core.Books.Queries.GetBookById;

public sealed class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, Book?>
{
    private readonly AppDbContext _appContext;

    private readonly ILogger<GetBookByIdQueryHandler> _logger;

    public GetBookByIdQueryHandler(AppDbContext appContext, ILogger<GetBookByIdQueryHandler> logger)
    {
        _appContext = appContext;
        _logger     = logger;
    }

    public async ValueTask<Book?> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
    {
        Book? book = await _appContext.Books.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        switch (book)
        {
            case not null:
                _logger.LogInformation(message: "Book with id {BookId} found", query.Id);

                break;

            default:
                _logger.LogWarning(message: "Book with id {BookId} not found", query.Id);

                break;
        }

        return book;
    }
}
