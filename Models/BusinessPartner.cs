
namespace API_SAP.Models
{
    public class BusinessPartner
    {
        public BusinessPartner(string? firtName, string? lastName, string? phone, string? cPF)
        {
            FirtName = firtName;
            LastName = lastName;
            Phone = phone;
            CPF = cPF;
        }

        public string? FirtName { get; private set; }
        public string? LastName { get; private set; }
        public string? Phone { get; private set; }
        public string? CPF { get; private set; }
        
    }
}