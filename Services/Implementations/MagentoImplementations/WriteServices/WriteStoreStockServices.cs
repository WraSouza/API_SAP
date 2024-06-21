using System.Net.Http.Headers;
using System.Text;
using API_SAP.Models;
using API_SAP.Services.Implementations.ReadServices.ReadStocks;
using Coravel.Invocable;
using Newtonsoft.Json;
using static API_SAP.Models.StoreStock;

namespace API_SAP.Services.Implementations.WriteServices.WriteStocks
{
    public class WriteStoreStockServices : IInvocable
    {             
          StoreStock storeStock = new();         

        public async Task Invoke()
        {
           await UpdateItensStock();
        }

        public async Task<bool> UpdateItensStock()
        {
           var content = File.ReadAllLines(@"C:\Users\wladimir.souza\Downloads\token.txt");

             HttpClientHandler clientHandler = new HttpClientHandler();
               clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };  

              bool resultado = true;              

               try
               {                         

                using (var client = new HttpClient(clientHandler))
                { 
                
                     ReadStockSAPServices readStockSAPServices= new ReadStockSAPServices();                   

                     List<SAPEstoque> listaSAPStock = readStockSAPServices.GetAll();

                     foreach(var itens in listaSAPStock)
                     {                       
                       client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", content[0]); 
                       
                        var response = client.GetAsync($"https://dev.lojatiaraju.com.br/rest/all/V1/stockItems/{itens.ItemCode}");
                        
                         string datasFromStore = await response.Result.Content.ReadAsStringAsync();

                         StockItem? items = JsonConvert.DeserializeObject<StockItem>(datasFromStore);

                        int idItemStore = items.item_id;                         
                        
                        if(int.Parse(itens.OnHand) > 0)
                        {
                            StockItem stockItem = new(idItemStore,items.product_id, items.stock_id,int.Parse(itens.OnHand), true);

                            storeStock = new(stockItem);
                        }
                        else
                        {
                          StockItem stockItem = new(idItemStore,items.product_id, items.stock_id,int.Parse(itens.OnHand), false);

                          storeStock = new(stockItem);
                        }
                       
                        string jsonString = JsonConvert.SerializeObject(storeStock);

                          //Atualizar
                          response = client.PutAsync($"https://dev.lojatiaraju.com.br/rest/all/V1/products/{itens.ItemCode}/stockItems/1",
                          new StringContent(jsonString, Encoding.UTF8, "application/json"));                         
                     }                      

                }          
               }catch(Exception ex)
               {
                 resultado = false;
               }

               return resultado;
        }
    }
}