using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SAP.Models
{
    public class Item
    {
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; }  = string.Empty;
        public string BarCode { get; set; }  = string.Empty;
    }
}