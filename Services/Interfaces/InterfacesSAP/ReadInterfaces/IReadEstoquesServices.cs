using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_SAP.Models;

namespace API_SAP.Services.Interfaces.IReadInterfaces.IReadEstoques
{
    public interface IReadSAPStocksServices
    {
        List<SAPEstoque> GetAll();
    }
}