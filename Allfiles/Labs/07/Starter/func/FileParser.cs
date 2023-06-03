using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
public static class FileParser
{
    /* Append an attribute to the Run method of type FunctionNameAttribute
       that has its name parameter set to a value of FileParser */
    [FunctionName("FileParser")]
    public static async Task<IActionResult> Run(
        /* Append an attribute to the request parameter of type  HttpTriggerAttribute
        that has its methods parameter array set to a single value of GET */
        [HttpTrigger("GET")] HttpRequest request)
    {
        /* Retrieve the value of the StorageConnectionString application setting by
           using the Environment.GetEnvironmentVariable method and to store the result
           in a string variable named connectionString */
        string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");
        BlobClient blob = new BlobClient(connectionString, "drop", "records.json");
        var response = await blob.DownloadAsync();
        /* Return the value of the connectionString variable as the HTTP response */
        return new FileStreamResult(response?.Value?.Content, response?.Value?.ContentType);
    }
}