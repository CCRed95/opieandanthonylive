using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp;
using opieandanthonylive.Common;
using opieandanthonylive.Data.API.Infrastructure;
using opieandanthonylive.Data.Domain.Audible;

namespace opieandanthonylive.Data.API.Audible
{
  public class AudibleAPI
    : APIBase<AudibleMediaItem>
  {
    private const string domainPrefix = "https://";
    private const string domainName = "audible";
    private const string domainSuffix = ".org";

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
    
    public override IEnumerable<AudibleMediaItem> Query()
    {
      var url = RequestBuilder
        .Builder
        .WithPath("search/")
        .WithPath("ref=sr_sort_publication_date")
        .WithParameter("searchAuthor", "Opie+Anthony")
        .WithParameter("searchRank", "publication_date")
        .WithParameter("field_language", "9178177011")
        .WithParameter("searchSize", "20")
        .WithParameter("searchRankSelect", "-publication_date")
        .Build();

      var context = BrowsingContext
        .New(
          Configuration
            .Default
            .WithDefaultLoader());

      var currentUrl = url;

      while (currentUrl != null)
      {
        var document = context
          .OpenAsync(currentUrl)
          .GetAwaiter()
          .GetResult();

        var items = document
          .QuerySelector(".adbl-search-results")
          .QuerySelectorAll(".adbl-result-item")
          .Select(
            t => t.QuerySelector(".adbl-prod-result"));

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


      }

      throw new NotImplementedException();

    }
  }
}