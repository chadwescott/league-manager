using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;

namespace LeagueManager.Api.Client.Utils
{
    public static class HttpClientUtil
    {
        public static HttpContent ToJsonContent(this object request)
        {
            var json = JsonConvert.SerializeObject(request);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
