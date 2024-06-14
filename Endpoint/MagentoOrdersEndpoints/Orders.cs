using System.Diagnostics;
using API_SAP.Models;
using API_SAP.Services.Implementations.ReadServices.ReadMagentoOrders;

namespace API_SAP.Endpoint.MagentoOrdersEndpoints
{
    public static class Orders
    {
        public static RouteGroupBuilder MagentoOrdersEndpoints(this RouteGroupBuilder app)
        {
            //Retornr Todos Itens
            app.MapGet("/busca-vendas", () =>
            {               
                  MagentoServices magentoServices = new();

                 var stopWatch = new Stopwatch();

                stopWatch.Start();       
        
                  var orders = magentoServices.GetMagentoClientsInOrders();
                  
                  stopWatch.Stop();

                  Console.WriteLine($"Finalizado Em: {stopWatch.Elapsed}");
                   return Results.Ok(orders);  

            }).Produces<MagentoOrder>(statusCode: StatusCodes.Status200OK)
              .Produces<MagentoOrder>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-Orders-Magento")
              .WithOpenApi();

              return app;
        }
    }
}