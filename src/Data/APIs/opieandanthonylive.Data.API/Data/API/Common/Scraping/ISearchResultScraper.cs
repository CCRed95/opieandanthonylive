
using AngleSharp.Dom;

namespace opieandanthonylive.Data.API.Common.Scraping
{
  public interface ISearchResultScraper<out TValue>
  {
    TValue Scrape(
      IElement htmlNode);
  }
}
