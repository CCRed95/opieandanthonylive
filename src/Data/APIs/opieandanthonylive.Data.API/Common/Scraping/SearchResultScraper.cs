using AngleSharp.Dom;

namespace opieandanthonylive.Common.Scraping
{
  public abstract class SearchResultScraper<TEntity>
    : ISearchResultScraper<TEntity>
  {
    public abstract TEntity Scrape(
      IElement htmlNode);
  }
}
