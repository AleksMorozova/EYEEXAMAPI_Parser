using System.Net.Http.Headers;
using System.Text;

namespace EYEEXAMAPI_Parser.Services
{
    // TODO: client should be disposable or added to DI
    public static class HttpClientFactory
    {
        public static HttpClient CreateClient(string baseURL) 
        {
            var client = new HttpClient();

            // TODO: Login and password should be stored in the secrete
            var authToken = Encoding.ASCII.GetBytes($"testy:mcTestFace");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
