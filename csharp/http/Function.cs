var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";

// Register the health check services
builder.Services.AddHealthChecks();  // This registers the health check services

// Build the application
var app = builder.Build();

// Health checks
app.MapHealthChecks("/health/liveness");
app.MapHealthChecks("/health/readiness");

// Handle the HTTP request body and return it as the response
app.MapPost("/", async (HttpRequest request) =>
{
    using var reader = new StreamReader(request.Body);
    var body = await reader.ReadToEndAsync();
    return Results.Ok(body);  // Return the body as the response
});

app.Run();
