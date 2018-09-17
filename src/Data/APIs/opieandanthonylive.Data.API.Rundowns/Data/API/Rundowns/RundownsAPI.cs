using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp;
using opieandanthonylive.Common;
using opieandanthonylive.Data.API.Infrastructure;
using opieandanthonylive.Data.API.Rundowns.Query;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.API.Rundowns
{
  public class RundownsAPI
    : APIBase<
      ShowRundown,
      RundownQueryBuilder>
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


    //var url = RequestBuilder
    //  .Builder
    //  .WithPath("vbulletin")
    //  .WithPath("archive")
    //  .WithPath("index.php")
    //  .WithPath("f-61.html")
    //  .Build();

    public override IEnumerable<ShowRundown> Query(
      RundownQueryBuilder queryBuilder)
    {
      var url = queryBuilder
        .BuilldRequestUrl(
          RequestBuilder);

      var context = BrowsingContext
        .New(
          Configuration
            .Default
            .WithDefaultLoader());

      using (var document = context
        .OpenAsync(url)
        .GetAwaiter()
        .GetResult())
      {
        var showRundownItems = document
          .QuerySelector("#content")
          .Children
          .First()
          .Children;
        
        foreach (var showRundownItem in showRundownItems)
        {
          var showRundownLink = showRundownItem.QuerySelector("a");

          var rundownUrl = showRundownLink.GetAttribute("href");
          var title = showRundownLink.TextContent;

          if (string.IsNullOrEmpty(rundownUrl))
            continue;

          throw new NotImplementedException();
          //yield return ShowRundownDeferred
          //  .ScrapeFromUrl(
          //    rundownUrl);
        }

      }

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
    }

  }
}
