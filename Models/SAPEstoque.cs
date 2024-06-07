using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SAP.Models
{
    public class SAPEstoque
    {
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? OnHand { get; set; }
    }
}