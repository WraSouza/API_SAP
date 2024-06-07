using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace API_SAP.Models
{
    public class Login
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Server { get; set; }
        public string? CompanyDB { get; set; }
        public SAPbobsCOM.BoDataServerTypes DbServerType { get; set; }
        public bool UseTrusted { get; set; }

         public Login()
        {
            UserName = "wladimir.souza";;
            Password = "Admin20*";
            Server = "linux-7lxj:30015";
            CompanyDB = "SBO_TIARAJU_HOM";
            DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
            UseTrusted = false;
        }           
       
    }
}