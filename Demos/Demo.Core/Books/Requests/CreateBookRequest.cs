namespace Demo.Core.Books.Requests;

public sealed record CreateBookRequest(List<string> AuthorNames, string Title);
