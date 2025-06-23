using Erdmier.DomainCore.Models.Identities;

namespace Demo.Core.Domain.BookAggregate.ValueObjects;

public sealed class AuthorId : EntityId<Guid>
{
    private AuthorId(Guid value)
        : base(value)
    { }

    public static AuthorId Create() => new(Guid.CreateVersion7());

    public static AuthorId Create(Guid value) => new(value);

    public static AuthorId Parse(string value)
    {
        try
        {
            return new AuthorId(Guid.Parse(value));
        }
        catch (Exception exception)
        {
            throw new Exception($"Unable to parse Author ID from {value}", exception);
        }
    }
}
