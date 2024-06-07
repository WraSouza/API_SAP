
using API_SAP.Models;
using API_SAP.Services.Implementations.ReadServices.ReadStocks;

namespace API_SAP.Endpoint.EstoqueEndpoints
{
    public static class Estoques
    {
        public static RouteGroupBuilder EstoquesEndpoints(this RouteGroupBuilder app)
        {            
            app.MapGet("/busca-estoques-sap", () =>
            {
                   ReadStockSAPServices readStocks = new();                  
                   var items = readStocks.GetAll();
                 
                   return Results.Ok(items);  

            }).Produces<Item>(statusCode: StatusCodes.Status200OK)
              .Produces<Item>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-Stocks-SAP")
              .WithOpenApi();                    

              return app;
        }
    }
}