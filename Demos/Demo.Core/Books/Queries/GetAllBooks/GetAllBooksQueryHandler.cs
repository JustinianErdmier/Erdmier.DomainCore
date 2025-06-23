namespace Demo.Core.Books.Queries.GetAllBooks;

public sealed class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, List<Book>>
{
    private readonly AppDbContext _appContext;

    private readonly ILogger<GetAllBooksQueryHandler> _logger;

    public GetAllBooksQueryHandler(AppDbContext appContext, ILogger<GetAllBooksQueryHandler> logger)
    {
        _appContext = appContext;
        _logger     = logger;
    }

    public async ValueTask<List<Book>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(message: "Getting all books");

            return await _appContext.Books.ToListAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            throw new Exception(message: "Error while getting all books", exception);
        }
    }
}
