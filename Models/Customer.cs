
namespace API_SAP.Models
{
    public class Customer
    {
        public Customer(string? fullName, string? cPF, List<string>? street, string? city, string? phone, string? email)
        {
            FullName = fullName;
            CPF = cPF;
            Street = street;
            City = city;
            Phone = phone;
            Email = email;
        }

        public string? FullName { get; private set; }
        public string? CPF { get; private set; }
        public List<string>? Street { get; private set; }
        public string? City { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
    }
}