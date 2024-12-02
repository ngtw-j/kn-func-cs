public interface IContext {
        string FunctionId { get; }
        string FunctionRuntime { get; }
        string FunctionAuthor { get; }
        string FunctionName { get; }
    }

    public class Context : IContext {
        public string FunctionId { get; private set; }
        public string FunctionRuntime { get; private set; }
        public string FunctionAuthor { get; private set; }
        public string FunctionName { get; private set; }

        public Context()
        {
            FunctionId = Environment.GetEnvironmentVariable("FAAS_FUNCTION_ID") ?? "";
            FunctionRuntime = Environment.GetEnvironmentVariable("FAAS_FUNCTION_RUNTIME") ?? "";
            FunctionAuthor = Environment.GetEnvironmentVariable("FAAS_FUNCTION_AUTHOR") ?? "";
            FunctionName = Environment.GetEnvironmentVariable("FAAS_FUNCTION_NAME") ?? "";
        }
    }

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

// TODO get cloudevent params
// TODO write boilerplate to return a cloudevent

app.MapGet("/", () =>
{   
    /*
	 * YOUR CODE HERE
	 *
	 * A HTTP Response will eventually get returned, but you can return anything like a string in the lambda function.
     * 
	 */
     
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})


app.Run();

