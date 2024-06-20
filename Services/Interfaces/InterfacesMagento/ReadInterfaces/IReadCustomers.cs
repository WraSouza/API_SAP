
using API_SAP.Models;


namespace API_SAP.Services.Interfaces.InterfacesMagento.ReadInterfaces
{
    public interface IReadCustomers
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Customer GetCustomerById(int id);
    }
}