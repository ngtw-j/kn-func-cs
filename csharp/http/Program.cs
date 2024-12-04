using Microsoft.AspNetCore.HttpLogging;

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";


var builder = WebApplication.CreateBuilder(args);

// Register the health check services
builder.Services.AddHealthChecks();
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;

    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

    logging.MediaTypeOptions.AddText("application/json"); 
    
    logging.CombineLogs = true;
});

// Build the application
var app = builder.Build();
app.UseHttpLogging();

// Health checks
app.MapHealthChecks("/health/liveness");
app.MapHealthChecks("/health/readiness");

// Handle the HTTP request body and return it as the response
app.MapPost("/", async (HttpRequest request) =>
{   
    /*
	 * YOUR CODE HERE
	 *
	 */
    using var reader = new StreamReader(request.Body);
    var body = await reader.ReadToEndAsync();


    return Results.Ok(body);  // Return the body as the response
});

app.Run();
