using Microsoft.EntityFrameworkCore;
using MSA.Phase2.AmazingApi.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerDocument(options =>
{
    options.DocumentName = "My Amazing API";
    options.Version = "V1";

});

builder.Services.AddHttpClient("pokemon", configureClient: client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co");
});

// Add DbContext Services
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext")));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();

