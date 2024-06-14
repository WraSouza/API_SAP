using API_SAP.Models;
using API_SAP.Services.Implementations.WriteServices.LoginService;
using API_SAP.Services.Interfaces.IReadInterfaces.IReadItens;

namespace API_SAP.Services.Implementations.ReadServices
{
    public class ReadItensServices : IReadItensServices
    {
        SAPbobsCOM.Company company= new SAPbobsCOM.Company(); 
                
        public List<Item> GetAll()
        {            
            List<Item> dataBaseItens = new List<Item>();
           
            LoginServices? result = new();

            var company = result.RealizarLogin();

            string sql = "SELECT * FROM OITM";

            SAPbobsCOM.Recordset ors = (SAPbobsCOM.Recordset)company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            ors.DoQuery(sql);

            int quantityItens = ors.RecordCount;

                for(int i = 0; i < quantityItens; i++)
                {
                    var item = new Item
                    {
                        ItemCode = ors.Fields.Item(0).Value.ToString(),
                        ItemName = ors.Fields.Item(1).Value.ToString(),
                        BarCode = ors.Fields.Item(6).Value.ToString()
                    };
                    dataBaseItens.Add(item);
                    ors.MoveNext();
                }
            
            
            return dataBaseItens;

        }
    }
}