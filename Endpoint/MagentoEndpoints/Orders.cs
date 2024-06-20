using System.Diagnostics;
using API_SAP.Models;
using API_SAP.Services.Implementations.MagentoImplementations.ReadServices;

namespace API_SAP.Endpoint.MagentoOrdersEndpoints
{
    public static class Orders
    {
        public static RouteGroupBuilder MagentoEndpoints(this RouteGroupBuilder app)
        {
            //Retornr Todos Itens
            app.MapGet("/busca-vendas", () =>
            {               
                CustomerServices magentoServices = new();

                 var stopWatch = new Stopwatch();

                stopWatch.Start();       
        
                  var orders = magentoServices.GetAllCustomersAsync();
                  
                  stopWatch.Stop();

                  Console.WriteLine($"Finalizado Em: {stopWatch.Elapsed}");
                   return Results.Ok(orders);  

            }).Produces<MagentoOrder>(statusCode: StatusCodes.Status200OK)
              .Produces<MagentoOrder>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-Orders-Magento")
              .WithOpenApi();

            app.MapGet("/busca-clientes", () =>
            {               
                CustomerServices customerServices = new();

                 var stopWatch = new Stopwatch();

                stopWatch.Start();       
        
                  var customers = customerServices.GetAllCustomersAsync();
                  
                  stopWatch.Stop();

                  Console.WriteLine($"Finalizado Em: {stopWatch.Elapsed}");
                   return Results.Ok(customers);  

            }).Produces<MagentoOrder>(statusCode: StatusCodes.Status200OK)
              .Produces<MagentoOrder>(statusCode: StatusCodes.Status400BadRequest)
              .WithName("Get-Customers-Magento")
              .WithOpenApi();

              return app;
        }
    }
}