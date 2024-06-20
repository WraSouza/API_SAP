using API_SAP.Models;

using API_SAP.Services.Implementations.ReadServices;

namespace API_SAP.Endpoint
{
    public static class Items
    {
        public static RouteGroupBuilder ItemsEndpoints(this RouteGroupBuilder app)
        {
            //Retornr Todos Itens
            app.MapGet("/itens", () =>
            {
                   ReadItensServices readItens = new();                  
                   var items = readItens.GetAll();
                 
                   return Results.Ok(items);  

            }).Produces<Item>(statusCode: StatusCodes.Status200OK)
              .Produces<Item>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-Items-SAP")
              .WithOpenApi();

              return app;
        }
    }
}