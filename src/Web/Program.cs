using Application.Interfaces;
using Application.ShortUrls;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "TodoAPI";
    config.Title = "TodoAPI v1";
    config.Version = "v1";
});

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("ShortUrl"));
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IShortUrlService, ShortUrlService>();

var app = builder.Build();

var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseInMemoryDatabase("ShortUrl")
    .Options;

using var context = new ApplicationDbContext(options);
context.Database.EnsureCreated();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "TodoAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapEndpoints();

app.Run();