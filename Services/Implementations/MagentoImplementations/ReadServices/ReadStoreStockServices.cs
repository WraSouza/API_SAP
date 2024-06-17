using System.Net.Http.Headers;
using API_SAP.Models;
using API_SAP.Services.Interfaces.IReadInterfaces.IReadStoreStocks;
using Newtonsoft.Json;

namespace API_SAP.Services.Implementations.ReadServices.ReadStoreStocks
{
    public class ReadStoreStockServices : IReadStoreStockServices
    {             
        public async Task<StoreStock> GetAll()
        {
            var content = File.ReadAllLines(@"C:\Users\wladimir.souza\Downloads\token.txt");
             HttpClientHandler clientHandler = new HttpClientHandler();
               clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 

            List<StoreStock> storeStocks = new List<StoreStock>();

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", content[0]);
               var response = client.GetAsync("https://dev.lojatiaraju.com.br/rest/all/V1/products?searchCriteria[currentPage]=1");                              
               
                string datasFromStore = await response.Result.Content.ReadAsStringAsync();

                StoreStock? itens = JsonConvert.DeserializeObject<StoreStock>(datasFromStore);

                return itens;
            }
        }
    }
}