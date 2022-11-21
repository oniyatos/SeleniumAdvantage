using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFramework.API_Core_HTTPClient
{
    public class HttpClientRequest
    {
        private static readonly HttpClient client = new HttpClient();
        public string url { get; set; }
        public string method { get; set; }
        public string body { get; set; }
        public int responseCode { get; set; }
        public string responseBody { get; set; }


        public HttpClientRequest(string url, string method, string body)
        {
            this.url = url;
            this.method = method;
            this.body = body;
        }

        public static async Task<string> GetRequest(string url)
        {
            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public void SendRequest()
        {
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;
            responseCode = (int)response.StatusCode;
            responseBody = response.Content.ReadAsStringAsync().Result;
        }
    }
}
