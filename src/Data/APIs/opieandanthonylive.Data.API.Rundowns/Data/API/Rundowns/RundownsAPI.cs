using System.Collections.Generic;
using AngleSharp;
using opieandanthonylive.Common;
using opieandanthonylive.Data.API.Infrastructure;
using opieandanthonylive.Data.API.Rundowns.DataSources;
using opieandanthonylive.Data.API.Rundowns.Materializers;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.API.Rundowns
{
  public class RundownsAPI
    : APIBase<ShowRundown>
  {
    private const string domainPrefix = "https://";
    private const string domainName = "struff";
    private const string domainSuffix = ".com";

    public static readonly string domain =
      $"{domainPrefix}{domainName}{domainSuffix}";

    private DomainFragment _requestBuilder;


    protected override DomainFragment RequestBuilder
    {
      get => _requestBuilder
             ?? (_requestBuilder
               = new DomainFragment(
                 domain));
    }

    public override IEnumerable<ShowRundown> Query()
    {
      foreach (var source in RundownDataSources.RundownDataSourceList)
      {
        var context = BrowsingContext
          .New(
            Configuration
              .Default
              .WithDefaultLoader());

        using (var document = context
          .OpenAsync(source.SourceStartPage)
          .GetAwaiter()
          .GetResult())
        {
          var threads = document
            .QuerySelector("#threads")
            .QuerySelectorAll(".threadbit");

          foreach (var thread in threads)
          {
            var showRundown = ShowRundownMaterializer
              .MaterializeThreadLevelShowMetadata(
                thread);

            yield return showRundown;
          }
        }
      }
    }
  }
}


/*


              //var showRundownLink = showRundownItem.QuerySelector("a");

            //var rundownUrl = showRundownLink.GetAttribute("href");
            //var title = showRundownLink.TextContent;

            //if (string.IsNullOrEmpty(rundownUrl))
            //  continue;

            //throw new NotImplementedException();
            //yield return ShowRundownDeferred
            //  .ScrapeFromUrl(
            //    rundownUrl);



  
          //yield return ShowRundownDeferred
          //  .ScrapeFromUrl(
          //    rundownUrl);
      //var items = document
      //    .QuerySelector(".adbl-search-results")
      //    .QuerySelectorAll(".adbl-result-item")
      //    .Select(
      //      t => t.QuerySelector(".adbl-prod-result"));

      throw new NotImplementedException();
      //var parsedItemMetadata = items
      //  .Select(AudibleItemMetadataScraper.Scrape)
      //  .ToArray();

      //yield return parsedItemMetadata;

      //var index = document
      //  .QuerySelector(".adbl-pagination-bottom")
      //  .QuerySelector(".adbl-page-index");

      //var nextLink = index
      //  .QuerySelector(".adbl-page-next");

      //var a = nextLink
      //  .QuerySelector("a");

      //if (a != null)
      //{
      //  var relativeLink = nextLink
      //    .QuerySelector("a")
      //    .GetAttribute("href");

      //  currentUrl = "https://www.audible.com" + relativeLink;
      //}
      //else
      //{
      //  currentUrl = null;
      //}


      //return new AudibleMediaItem[] { };
 *  .WithPath("vbulletin/")
        .WithPath("archive/")
        .WithParameter("searchAuthor", "Opie+Anthony")
        .WithParameter("searchRank", "publication_date")
        .WithParameter("field_language", "9178177011")
        .WithParameter("searchSize", "20")
        .WithParameter("searchRankSelect", "-publication_date")
        .Build();

  
    //public static string url
    //    = "https://www.audible.com/" +
    //      "search/" +
    //      "ref=sr_sort_publication_date" +
    //      "?searchAuthor=Opie+Anthony" +
    //      "&searchRank=publication_date" +
    //      "&field_language=9178177011" +
    //      "&searchSize=20" +
    //      "&searchRankSelect=-publication_date" +
    //      "&searchsize=20";
    //public static string url
    //  = @"http://www.struff.com/vbulletin/archive/index.php/f-61.html";

 */
