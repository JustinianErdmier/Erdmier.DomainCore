namespace Demo.Core.Domain.BookAggregate.Entities;

public sealed class Author : EntityWithDomainEvents<AuthorId>
{
    private Author(string name, AuthorId? id = null)
        : base(id ?? AuthorId.Create())
        => Name = name;

    private Author()
    { }

    public string Name { get; private set; } = null!;

    public void ChangeName(string newName)
    {
        AuthorNameChangedEvent domainEvent = AuthorNameChangedEvent.Create(Id, Name, newName);

        AddDomainEvent(domainEvent);

        Name = newName;
    }

    public static Author Create(string name) => new(name);
}
