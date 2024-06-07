using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_SAP.Services.Interfaces.IWriteInterfaces.ILogin
{
    public interface ILoginService
    {
        SAPbobsCOM.Company RealizarLogin();
    }
}