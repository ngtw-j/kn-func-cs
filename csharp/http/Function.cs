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

// Health checks
app.MapGet("/health/liveness", () =>
{
    // Return a 200 OK status to indicate that the service is alive
    return Results.Ok("Liveness check successful");
});

app.MapGet("/health/readiness", () =>
{
    // You can perform more complex readiness checks here if needed.
    // For example, check if a database connection is available.
    return Results.Ok("Readiness check successful");
});

app.Run();
