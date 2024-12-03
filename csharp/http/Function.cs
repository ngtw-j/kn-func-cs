var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";

// Build the application
var app = builder.Build();

// Handle the HTTP request body and return it as the response
app.MapPost("/", async (HttpRequest request) =>
{
    using var reader = new StreamReader(request.Body);
    var body = await reader.ReadToEndAsync();
    return Results.Ok(body);  // Return the body as the response
});

app.Run();
