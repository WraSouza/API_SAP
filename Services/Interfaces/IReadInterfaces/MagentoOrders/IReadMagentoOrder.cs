using API_SAP.Models;


namespace API_SAP.Services.Interfaces.IReadInterfaces.MagentoOrders
{
    public interface IReadMagentoOrder
    {
        Task<List<BusinessPartner>> GetMagentoClientsInOrders();
    }
}