
using API_SAP.Models;
using API_SAP.Services.Implementations.WriteServices.LoginService;
using API_SAP.Services.Interfaces.IReadInterfaces.IReadSAPBP;

namespace API_SAP.Services.Implementations.ReadServices
{
    public class ReadBPSAP : IBusinessPartner
    {                  
        public bool ConfirmBPExist(string name, string cpf)
        {           
            string sql = $"SELECT * FROM OCRD T0 WHERE T0.\"CardName\" =  {name.ToUpper().Replace("'","")}";
           
            bool bpExists = false;           

            LoginServices? result = new();

            var company = result.RealizarLogin();

             SAPbobsCOM.Recordset ors = (SAPbobsCOM.Recordset)company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
             ors.DoQuery(sql);
             int quantityItens = ors.RecordCount;

             if(quantityItens > 0)
             {
                bpExists = true;
             }

             return bpExists;
        }

        public int CreateBP(BusinessPartner businssPartner)
        {
            throw new NotImplementedException();
        }
        
        public async Task<List<BusinessPartnerSAP>> GetAll()
        {
            
            List<BusinessPartnerSAP> businessPartner = new();           
                
                LoginServices? result = new();
                var company = result.RealizarLogin();                
                
                string sql = "SELECT * FROM OCRD";

                SAPbobsCOM.Recordset ors = (SAPbobsCOM.Recordset)company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                ors.DoQuery(sql);
                int quantityItens = ors.RecordCount;

                for(int i = 0; i < quantityItens; i++)
                {
                    var bp = new BusinessPartnerSAP
                    {
                        CardCode = ors.Fields.Item(0).Value.ToString(),
                        CardName = ors.Fields.Item(1).Value.ToString(),
                        City = ors.Fields.Item(50).Value.ToString(),
                        Address = ors.Fields.Item(5).Value.ToString()

                    };
                    
                    businessPartner.Add(bp);
                    ors.MoveNext();
                }                          

           return businessPartner;
        }
    }
}