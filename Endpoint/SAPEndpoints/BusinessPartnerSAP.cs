using System.Diagnostics;
using API_SAP.Models;
using API_SAP.Services.Implementations.ReadServices;
using Microsoft.AspNetCore.Mvc;

namespace API_SAP.Endpoint.BusinessPartnerEndpoints
{
    public static class BusinessPartnerSAP
    {        
         public static RouteGroupBuilder BusinessPartnerEndpoints(this RouteGroupBuilder app)
        {
            
            app.MapGet("/businesspartner", () =>
            {               
                 var stopWatch = new Stopwatch();

                  stopWatch.Start(); 

                  ReadBPSAP readBPSAP = new();
                                  
                  var items = readBPSAP.GetAll();

                  stopWatch.Stop();

                  Console.WriteLine($"Finalizado Em: {stopWatch.Elapsed}");
                 
                   return Results.Ok(items); 

            }).Produces<BusinessPartner>(statusCode: StatusCodes.Status200OK)
              .Produces<BusinessPartner>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-BP-SAP")
              .WithOpenApi();      

              app.MapGet("/businesspartner/name", ([FromBody]Customer customer) =>
            {                                 
                   return Results.Ok(); 

            }).Produces<BusinessPartner>(statusCode: StatusCodes.Status200OK)
              .Produces<BusinessPartner>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-BP-Name-SAP")
              .WithOpenApi();   

            app.MapPost("/businesspartner", ([FromBody]Customer customer) =>
            {                 
                   return Results.Ok(); 

            }).Produces<BusinessPartner>(statusCode: StatusCodes.Status200OK)
              .Produces<BusinessPartner>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Post-BP-SAP")
              .WithOpenApi();          

              return app;
        }

        
    }
}