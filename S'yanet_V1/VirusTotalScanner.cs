using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;

namespace S_yanet_V1
{
    class VirusTotalScanner
    {
        private readonly string apiKey;
        private readonly HttpClient httpClient;

        public VirusTotalScanner(string apiKey)
        {
            this.apiKey = apiKey;
            httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("https://www.virustotal.com/api/v2/");
            httpClient.BaseAddress = new Uri("https://www.virustotal.com/api/v3/");
            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Add("x-apikey", this.apiKey);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> ScanFileAsync(string filePath)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "files");
            
            // content headerlarını sadece content ile kullan
            var content = new MultipartFormDataContent();
            // content.Headers.Add("content-type", "multipart/form-data");
            HttpResponseMessage response;
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                content.Add(new StreamContent(fileStream), "file", Path.GetFileName(filePath));
                request.Content = content;

                response = await httpClient.SendAsync(request);
            }

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                return "Error: " + response.StatusCode;
            }
        }

        public async Task<string> ScanUrlAsync(string url)
        {
            //var request = new HttpRequestMessage(HttpMethod.Post, "url/scan");
            var request = new HttpRequestMessage(HttpMethod.Post, "urls");
            //request.Headers.Add("x-apikey", apiKey);

            //var jsonContent = new StringContent($"{{\"url\": \"{url}\"}}");
            //jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //request.Content = jsonContent;

            request.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("url", url)
            });

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                return "Error: " + response.StatusCode;
            }
        }

        public async Task<string> GetURLIDResults(string vtID)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"analyses/{vtID}");

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }

            /*
            var request = new HttpRequestMessage(HttpMethod.Get, $"url/report?apikey={apiKey}&resource={urlID}");
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                return "Error: " + response.StatusCode;
            }
            */
        }
    }
}
