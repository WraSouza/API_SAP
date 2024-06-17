using System.Diagnostics;
using API_SAP.Models;
using API_SAP.Services.Implementations.ReadServices.ReadStoreStocks;
using API_SAP.Services.Implementations.WriteServices.WriteStocks;
using Microsoft.Extensions.Options;

namespace API_SAP.Endpoint.EstoqueEndpoints
{
  public static class StoreInStock
  {
    
    public static RouteGroupBuilder StockInStoreEndpoints(this RouteGroupBuilder app)
    {
      //Atualizar Estoque Loja Tiaraju
      app.MapPut("/atualizar-estoque-loja", async () =>
      {
        WriteStoreStockServices writeStoreStockServicesStocks = new();

        var stopWatch = new Stopwatch();

        stopWatch.Start();
        bool resultado = await writeStoreStockServicesStocks.UpdateItensStock();
        stopWatch.Stop();

        Console.WriteLine($"Finalizado Em: {stopWatch.Elapsed}");



        if (resultado)
        {
          return Results.Ok("Dados Atualizados.");
        }

        return Results.BadRequest("Não Foi Possível Concluir a Operação.");

      }).Produces<StoreStock>(statusCode: StatusCodes.Status200OK)
      .Produces<StoreStock>(statusCode: StatusCodes.Status400BadRequest)
      .WithName("Update-Stocks-Store")
      .WithOpenApi();

      app.MapGet("/busca-estoque-loja", () =>
     {
       ReadStoreStockServices readStoreStockServices = new();

       var items = readStoreStockServices.GetAll();

       return Results.Ok(items);

     }).Produces<StoreStock>(statusCode: StatusCodes.Status200OK)
     .Produces<StoreStock>(statusCode: StatusCodes.Status400BadRequest)
     .WithName("Get-Stocks-Store")
     .WithOpenApi();

      return app;
    }


  }
}