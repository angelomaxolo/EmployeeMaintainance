using System;
using System.Net.Http;

namespace EmployeeMaintainance.Web
{
    public class HttpClientFactory : IHttpClientFactory
    {

            private const string BaseAddress = "http://localhost:55705";

            public HttpClient CreateHttpClient()
            {
                var client = new HttpClient();
                SetupClientDefaults(client);

                return client;
            }

            private static void SetupClientDefaults(HttpClient client)
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Clear();
            }
        
    }
}
