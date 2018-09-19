using System.Threading.Tasks;

namespace opieandanthonylive.Data.API.Web
{
  public interface IHttpClient
  {
    Task<string> GetContentAsync(string address);
  }
}