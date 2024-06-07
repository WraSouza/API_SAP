using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_SAP.Models;

namespace API_SAP.Services.Interfaces.IReadInterfaces.IReadStoreStocks
{
    public interface IReadStoreStockServices
    {
       Task<StoreStock> GetAll();
    }
}