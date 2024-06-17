using System.Diagnostics;
using API_SAP.Models;
using API_SAP.Services.Implementations.ReadServices;

namespace API_SAP.Endpoint.BusinessPartnerEndpoints
{
    public static class BusinessPartnerSAP
    {
         public static RouteGroupBuilder BusinessPartnerEndpoints(this RouteGroupBuilder app)
        {
            //Retornr Todos Itens
            app.MapGet("/busca-businesspartner-sap", () =>
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

            

              return app;
        }

        
    }
}