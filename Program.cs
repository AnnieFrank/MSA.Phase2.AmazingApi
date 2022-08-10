var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerDocument(options =>
{
    options.DocumentName = "My Amazing API";
    options.Version = "V1";

});

builder.Services.AddHttpClient("reddit", configureClient: client =>
{
    client.BaseAddress = new Uri("https://www.reddit.com/dev/api");
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();

