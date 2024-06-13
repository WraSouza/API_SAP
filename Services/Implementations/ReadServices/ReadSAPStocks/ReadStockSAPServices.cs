using API_SAP.Models;
using API_SAP.Services.Implementations.WriteServices.LoginService;
using API_SAP.Services.Interfaces.IReadInterfaces.IReadEstoques;

namespace API_SAP.Services.Implementations.ReadServices.ReadStocks
{
    public class ReadStockSAPServices : IReadSAPStocksServices
    {
         //SAPbobsCOM.Company company= new SAPbobsCOM.Company(); 
        int connectionCode;
        public List<SAPEstoque> GetAll()
        {              
             List<SAPEstoque> dataBaseItens = new List<SAPEstoque>(); 

            try
            {
                LoginServices? result = new();

                var company = result.RealizarLogin();

           
                string sql = "SELECT * FROM TJ_ESTOQUE";

                SAPbobsCOM.Recordset ors = (SAPbobsCOM.Recordset)company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                ors.DoQuery(sql);
                int quantityItens = ors.RecordCount;

                for(int i = 0; i < quantityItens; i++)
                {
                    var stock = new SAPEstoque
                    {
                        ItemCode = ors.Fields.Item(0).Value.ToString(),
                        ItemName = ors.Fields.Item(1).Value.ToString(),
                        OnHand = ors.Fields.Item(3).Value.ToString()                       
                    };
                    dataBaseItens.Add(stock);
                    ors.MoveNext();
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
           
            return dataBaseItens;
        }
    }
}