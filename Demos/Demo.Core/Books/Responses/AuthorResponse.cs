namespace Demo.Core.Books.Responses;

public sealed record AuthorResponse(Guid Id, string Name)
{
    public static AuthorResponse Create(Guid id, string name) => new(id, name);
}
