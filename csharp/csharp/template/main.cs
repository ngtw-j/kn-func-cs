using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnativeFunction
{
    public class Function
    {
        private readonly ILogger<Function> _logger;

        public Function(ILogger<Function> logger)
        {
            _logger = logger;
        }

        [FunctionName("Function_HttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Hello from Knative C# function!");
        }
    }
}
