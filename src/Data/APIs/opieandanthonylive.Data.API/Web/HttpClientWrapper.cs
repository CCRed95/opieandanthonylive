using System;
using System.Net.Http;
using System.Threading.Tasks;
using opieandanthonylive.Data.API.Web;

namespace opieandanthonylive.Web
{
  public class HttpClientWrapper
    : IHttpClient,
      IDisposable
  {
    private readonly HttpClient Client;

    public HttpClientWrapper()
    {
      Client = new HttpClient();
      Client
        .DefaultRequestHeaders
        .Add(
          "User-Agent",
          "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.11 Safari/537.36");
    }

    public async Task<string> GetContentAsync(
      string address)
    {
      return await Client.GetStringAsync(address);
    }

    public void Dispose()
    {
      Client.Dispose();
    }
  }
}