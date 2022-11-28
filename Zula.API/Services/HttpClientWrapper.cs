using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Zula.API.Services
{
    public class HttpClientWrapper : Interfaces.Services.IHttpClient
    {
		private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
			_httpClient = httpClient;
        }
        public async System.Threading.Tasks.Task<T> SendHttpRequestAsync<T>(
			HttpMethod httpMethod,
			string baseUri,
			string queryParams,
			Dictionary<string, string> headersKVP)
        {
			var request = new HttpRequestMessage
			{
				Method = httpMethod,
				RequestUri = new Uri(baseUri + queryParams)
			};
			foreach (var headerKV in headersKVP)
            {
				request.Headers.Add(headerKV.Key, headerKV.Value);
            }

			T apiResponse;
			
			using (var response = await _httpClient.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				apiResponse = JsonSerializer.Deserialize<T>(body);
			}
			return apiResponse;
		}
    }
}
