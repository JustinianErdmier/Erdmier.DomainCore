namespace Demo.Core.Books.Commands.ChangeAuthorName;

public sealed class ChangeAuthorNameCommandHandler : ICommandHandler<ChangeAuthorNameCommand, bool>
{
    private readonly AppDbContext _appContext;

    private readonly ILogger<ChangeAuthorNameCommandHandler> _logger;

    public ChangeAuthorNameCommandHandler(AppDbContext appContext, ILogger<ChangeAuthorNameCommandHandler> logger)
    {
        _appContext = appContext;
        _logger     = logger;
    }

    public async ValueTask<bool> Handle(ChangeAuthorNameCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Book? book = await _appContext.Books.FirstOrDefaultAsync(x => x.Id == command.BookId, cancellationToken);

            if (book is null)
            {
                _logger.LogWarning(message: "Book with id {BookId} not found", command.Id);

                return false;
            }

            Author? author = book.Authors.FirstOrDefault(x => x.Id == command.Id);

            if (author is null)
            {
                _logger.LogWarning(message: "Author with id {AuthorId} not found", command.Id);

                return false;
            }

            _logger.LogInformation(message: "Changing the name for author {AuthorId}", command.Id);

            author.ChangeName(command.Name);

            await _appContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(message: "Name for author {AuthorId} has been changed", command.Id);

            return true;
        }
        catch (Exception exception)
        {
            throw new Exception($"Error while changing author name for author {command.Id}", exception);
        }
    }
}
