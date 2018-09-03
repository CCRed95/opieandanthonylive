using System.Collections.Generic;

namespace opieandanthonylive.Common.Scraping
{
  public abstract class SearchScraper
    : ISearchScraper
  {
    public abstract IEnumerable<TEntity> Scrape<TEntity>(
      string htmlContent);
  }
}
