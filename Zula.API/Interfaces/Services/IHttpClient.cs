using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Zula.API.Interfaces.Services
{
    public interface IHttpClient
    {
        public Task<T> SendHttpRequestAsync<T>(HttpMethod httpMethod, string baseUri, string queryParams, Dictionary<string, string> headers);
    }
}
