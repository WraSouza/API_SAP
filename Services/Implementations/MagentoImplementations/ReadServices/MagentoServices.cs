using System.Net.Http.Headers;
using API_SAP.Models;
using API_SAP.Services.Interfaces.IReadInterfaces.MagentoOrders;
using Newtonsoft.Json;
using static API_SAP.Models.MagentoOrder;

namespace API_SAP.Services.Implementations.ReadServices.ReadMagentoOrders
{
    public class MagentoServices : IReadMagentoOrder
    {
        readonly string url = "https://www.lojatiaraju.com.br/rest/all/V1/orders?searchCriteria[currentPage]=1";
        readonly string token = "6w7u59qsd34uuyc3sxikd4x50kh23f6p";
        public async Task<List<BusinessPartner>> GetMagentoClientsInOrders()
        {
           Root? dataBaseItens = new Root(); 
           List<Payment> payment = new();
           List<BusinessPartner> businessPartner = new();   
           List<BusinessPartner> bpSAP = new();      

            HttpClientHandler clientHandler = new HttpClientHandler();
               clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 

                using (var client = new HttpClient(clientHandler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    Task<HttpResponseMessage> response =  client.GetAsync(url);                                     

                    string datasFromStore = await response.Result.Content.ReadAsStringAsync();

                    dataBaseItens = JsonConvert.DeserializeObject<Root>(datasFromStore);                                     

                    var qtdyOrdersNotCancelled = dataBaseItens?.items?.FindAll(x => x.status == "processing");                       

                    for(int i = 0; i < qtdyOrdersNotCancelled.Count ; i++)
                    {
                        payment.Add(qtdyOrdersNotCancelled[i].payment);
                    }                              

                    if(qtdyOrdersNotCancelled != null)
                    {
                        for(int i = 0; i < qtdyOrdersNotCancelled.Count ; i++)
                        {
                            BusinessPartner bp = new(qtdyOrdersNotCancelled[i]?.billing_address?.firstname, qtdyOrdersNotCancelled[i]?.billing_address?.lastname, qtdyOrdersNotCancelled[i]?.billing_address?.telephone, qtdyOrdersNotCancelled[i]?.billing_address?.vat_id);
                          
                                               
                            var result = businessPartner.FindAll(x => x.FirtName == bp.FirtName?.Trim() && x.LastName == bp.LastName);

                            if(result.Count == 0)
                            businessPartner.Add(bp);
                        } 

                         ReadBPSAP readBPSAP = new();
                  
                    }                                                
                                 
                }             

            return bpSAP;
        }

        
    }
}