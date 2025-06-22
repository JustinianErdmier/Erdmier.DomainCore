namespace Demo.Core.EventHandlers;

public sealed class BookTitleChangedEventHandler : INotificationHandler<BookTitleChangedEvent>
{
    private readonly ILogger<BookTitleChangedEventHandler> _logger;

    public BookTitleChangedEventHandler(ILogger<BookTitleChangedEventHandler> logger) => _logger = logger;

    public async ValueTask Handle(BookTitleChangedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message: "Title of book {BookId} has been changed from {OldBookTitle} to {NewBookTitle}",
                               notification.Id,
                               notification.OldTitle,
                               notification.NewTitle);

        await Task.CompletedTask;
    }
}
