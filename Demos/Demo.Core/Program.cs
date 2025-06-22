using Demo.Core.Books.Commands.ChangeAuthorName;
using Demo.Core.Books.Commands.ChangeBookTitle;
using Demo.Core.Books.Commands.CreateBook;
using Demo.Core.Books.Queries.GetAllBooks;
using Demo.Core.Books.Queries.GetBookById;
using Demo.Core.Books.Requests;
using Demo.Core.Books.Responses;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices()
       .AddPersistence(builder.Configuration, builder.Environment);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost(pattern: "/books",
            async (CreateBookRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                CreateBookCommand command = CreateBookCommand.Create(request.AuthorNames, request.Title);

                BookId bookId = await sender.Send(command, cancellationToken);

                return Results.Created($"/books/{bookId}",
                                       new
                                       {
                                           BookId = bookId.Value
                                       });
            });

app.MapGet(pattern: "/books",
           async (ISender sender, CancellationToken cancellationToken) =>
           {
               GetAllBooksQuery query = GetAllBooksQuery.Create();

               List<Book> books = await sender.Send(query, cancellationToken);

               return Results.Ok(BookResponse.Create(books));
           });

app.MapGet(pattern: "/books/{id:guid}",
           async (Guid id, ISender sender, CancellationToken cancellationToken) =>
           {
               GetBookByIdQuery query = GetBookByIdQuery.Create(BookId.Create(id));

               Book? book = await sender.Send(query, cancellationToken);

               return book is null ? Results.NotFound() : Results.Ok(BookResponse.Create(book));
           });

app.MapPost(pattern: "/books/{id:guid}",
            async (Guid id, ChangeBookTitleRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                ChangeBookTitleCommand command = ChangeBookTitleCommand.Create(BookId.Create(id), request.Title);

                bool result = await sender.Send(command, cancellationToken);

                return result ? Results.Ok() : Results.BadRequest();
            });

app.MapPost(pattern: "/books/{bookId:guid}/authors/{id:guid}",
            async (Guid bookId, Guid id, ChangeAuthorNameRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                ChangeAuthorNameCommand command = ChangeAuthorNameCommand.Create(BookId.Create(bookId), AuthorId.Create(id), request.Name);

                bool result = await sender.Send(command, cancellationToken);

                return result ? Results.Ok() : Results.BadRequest();
            });

app.Run();
