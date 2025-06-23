namespace Demo.Core.Books.EventHandlers;

public sealed class AuthorNameChangedEventHandler : INotificationHandler<AuthorNameChangedEvent>
{
    private readonly ILogger<AuthorNameChangedEventHandler> _logger;

    public AuthorNameChangedEventHandler(ILogger<AuthorNameChangedEventHandler> logger) => _logger = logger;

    public async ValueTask Handle(AuthorNameChangedEvent domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message: "Name of Author {AuthorId} has been changed from {OldAuthorName} to {NewAuthorName}",
                               domainEvent.Id,
                               domainEvent.OldName,
                               domainEvent.NewName);

        await Task.CompletedTask;
    }
}
