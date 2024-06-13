using API_SAP.Models;

namespace API_SAP.Services.Interfaces.IReadInterfaces.IReadSAPBP
{
    public interface IBusinessPartner
    {
        bool ConfirmBPExist(string name);
        int CreateBP(BusinessPartner businssPartner);
        //Task<List<BusinessPartner>> GetAll(List<BusinessPartner> businessPartners);
        Task<List<BusinessPartnerSAP>> GetAll();
    }
}