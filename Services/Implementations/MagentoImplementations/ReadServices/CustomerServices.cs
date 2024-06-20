
using System.Net.Http.Headers;
using API_SAP.Models;
using API_SAP.Services.Interfaces.InterfacesMagento.ReadInterfaces;
using Newtonsoft.Json;
using static API_SAP.Models.MagentoOrder;

namespace API_SAP.Services.Implementations.MagentoImplementations.ReadServices
{
    public class CustomerServices : IReadCustomers
    {
        readonly string url = "https://www.lojatiaraju.com.br/rest/all/V1/orders?searchCriteria[currentPage]=1";
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
             var content = File.ReadAllLines(@"C:\Users\wladimir.souza\Downloads\token.txt");                                 

             List<Customer> Customers = new ();

              HttpClientHandler clientHandler = new HttpClientHandler();
               clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

               using (var client = new HttpClient(clientHandler))
               {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", content[0]);

                    Task<HttpResponseMessage> response =  client.GetAsync(url);

                    string dataFromStore = await response.Result.Content.ReadAsStringAsync();

                    var root = JsonConvert.DeserializeObject<Root>(dataFromStore);
                    
                    for(int i = 0; i < root?.total_count; i++)
                    {                      
                       string fullName = root?.items?[i].customer_firstname + " " + root?.items?[i].customer_lastname;
                       Customer customerItem = new(fullName.ToUpper() , root?.items?[i].billing_address?.vat_id, root?.items?[i].billing_address?.street, root?.items?[i].billing_address?.city,root?.items?[i].billing_address?.telephone,root?.items?[i].customer_email);
                       
                       var quantity = Customers.FindAll(x => x.FullName == fullName.ToUpper());

                       if(quantity.Count == 0)
                       Customers.Add(customerItem);
                    }                   
                    
               }
        
               return Customers;
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}