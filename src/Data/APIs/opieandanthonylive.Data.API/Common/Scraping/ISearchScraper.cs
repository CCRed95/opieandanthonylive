using System.Collections.Generic;

namespace opieandanthonylive.Common.Scraping
{
  public interface ISearchScraper
  {
    IEnumerable<TEntity> Scrape<TEntity>(
      string htmlContent);
  }
}
