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

// TODO: Add minimal API endpoints here...

app.Run();
