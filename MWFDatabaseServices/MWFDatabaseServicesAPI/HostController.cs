/*using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MWFDataLibrary.BuisnessLogic;
using System.Text.Json;
using MWFModelsLibrary.Models;
using System.Collections.Generic;

namespace MWFDatabaseServicesAPI
{
    public static class HostController
    {
        [FunctionName("CreateHostAndReturnId")]
        public static async Task<IActionResult> CreateHostAndReturnId(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("processing CreateHostAndReturnId endpoint");

            // get the body in json format (there may be a better way to do this)
            string requestBody = await req.ReadAsStringAsync();
            JsonElement jsonBody = JsonSerializer.Deserialize<JsonElement>(requestBody);
            *//*HostModel host = JsonSerializer.Deserialize<HostModel>(requestBody);*//*

            // get all of the values we need for the HostProcessor (maybe deserialize json to a HostModel instead? Or maybe just pass a HostModel with a null Id to this endpoint)
            int reqGame = jsonBody.GetProperty("Game").GetInt32();
            string reqPort = jsonBody.GetProperty("Port").GetString();
            string reqArgs = jsonBody.GetProperty("Args").GetString();
            int reqHostId = jsonBody.GetProperty("HostId").GetInt32();

            // hard coded connection string for now
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MWFDatabaseServicesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            // call on the data processor and store the returned Id
            int retVal = await HostProcessor.CreateHostAndReturnIdAsync(connectionString, reqGame, reqPort, reqArgs, reqHostId);

            // Remember, returning a good result means the game instance is currentlly running
            return new OkObjectResult(retVal);
        }

        [FunctionName("DeleteHostById")]
        public static async Task<IActionResult> DeleteHostById(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("hostID = " *//*+ hostID.ToString()*//*);


            // get the body in json format (there may be a better way to do this)
            string requestBody = await req.ReadAsStringAsync();
            int hostId = int.Parse(requestBody);

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MWFDatabaseServicesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            int rowsDeleted = await HostProcessor.DeleteHostByIdAsync(connectionString, hostId);

            // Passing an int into the OkObjectResult will put the int in the body
            return new OkObjectResult(rowsDeleted);
        }

        [FunctionName("GetHosts")]
        public static async Task<IActionResult> GetHosts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MWFDatabaseServicesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            IEnumerable<HostModel> Hosts = await HostProcessor.GetHostsAsync(connectionString);
            // Passing an IEnumerable into the OkObjectResult will put it in the body
            return new OkObjectResult(Hosts);
        }

    }
}
*/