using System.Collections.Generic;

namespace opieandanthonylive.Data.API.Common.Scraping
{
  public interface ISearchScraper
  {
    IEnumerable<TEntity> Scrape<TEntity>(
      string htmlContent);
  }
}
