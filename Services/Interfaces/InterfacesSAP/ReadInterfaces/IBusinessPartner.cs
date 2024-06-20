using API_SAP.Models;

namespace API_SAP.Services.Interfaces.IReadInterfaces.IReadSAPBP
{
    public interface IBusinessPartner
    {
        bool ConfirmBPExist(string name, string cpf);
        int CreateBP(BusinessPartner businssPartner);        
        Task<List<BusinessPartnerSAP>> GetAll();
    }
}