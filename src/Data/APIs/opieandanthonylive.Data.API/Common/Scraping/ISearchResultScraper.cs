
using AngleSharp.Dom;

namespace opieandanthonylive.Common.Scraping
{
  public interface ISearchResultScraper<out TValue>
  {
    TValue Scrape(
      IElement htmlNode);
  }
}
