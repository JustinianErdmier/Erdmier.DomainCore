namespace Demo.Core.Books.Commands.ChangeBookTitle;

public sealed class ChangeBookTitleCommandHandler : ICommandHandler<ChangeBookTitleCommand, bool>
{
    private readonly AppDbContext _appContext;

    private readonly ILogger<ChangeBookTitleCommandHandler> _logger;

    public ChangeBookTitleCommandHandler(AppDbContext appContext, ILogger<ChangeBookTitleCommandHandler> logger)
    {
        _appContext = appContext;
        _logger     = logger;
    }

    public async ValueTask<bool> Handle(ChangeBookTitleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Book? book = await _appContext.Books.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            if (book is null)
            {
                return false;
            }

            book.ChangeTitle(command.Title);

            _logger.LogInformation(message: "Changing the title for book {BookId}", book.Id);

            await _appContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(message: "Title for book {BookId} has been changed", book.Id);

            return true;
        }
        catch (Exception exception)
        {
            throw new Exception($"Error while changing book title for book {command.Id}", exception);
        }
    }
}
