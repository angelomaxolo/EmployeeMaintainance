using System.Net.Http;

namespace EmployeeMaintainance.Web
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}
