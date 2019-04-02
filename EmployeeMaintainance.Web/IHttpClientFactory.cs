using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeMaintainance.Web
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}
