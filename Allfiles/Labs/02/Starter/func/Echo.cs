 using Microsoft.AspNetCore.Mvc;
 using Microsoft.Azure.WebJobs;
 using Microsoft.AspNetCore.Http;
 using Microsoft.Extensions.Logging;

 public static class Echo
 {
    [FunctionName("Echo")]
    public static IActionResult Run([HttpTrigger("POST")] HttpRequest request, ILogger logger)
    {
        logger.LogInformation("Request recibida!! .. " + request.Body.ToString());
        return new OkObjectResult(request.Body);
    }
 }