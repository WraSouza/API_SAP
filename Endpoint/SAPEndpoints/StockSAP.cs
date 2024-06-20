
using API_SAP.Models;

namespace API_SAP.Endpoint.SAPEndpoints
{
    public static class StockSAP
    {
        public static RouteGroupBuilder StockSAPEndpoints(this RouteGroupBuilder app)
        {
            //Retornr Todos Itens
            app.MapGet("/estoque-sap", () =>
            {                   
                   return Results.Ok();  

            }).Produces<SAPEstoque>(statusCode: StatusCodes.Status200OK)
              .Produces<SAPEstoque>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-Stock-SAP")
              .WithOpenApi();

              return app;
        }
        
    }
}