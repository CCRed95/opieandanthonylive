using System.Collections.Generic;
using AngleSharp;
using opieandanthonylive.Common;
using opieandanthonylive.Data.API.Audible.Scraping;
using opieandanthonylive.Data.API.Infrastructure;
using opieandanthonylive.Data.Domain.Audible;

namespace opieandanthonylive.Data.API.Audible
{
  public class AudibleAPI
    : APIBase<AudibleMediaItem>
  {
    private const string domainPrefix = "https://";
    private const string domainName = "audible";
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

      var audibleSearchResultScraper = new AudibleSearchResultScraper();

      while (currentUrl != null)
      {
        using (var document = context
          .OpenAsync(currentUrl)
          .GetAwaiter()
          .GetResult())
        {
          var items = document
            .QuerySelector("#center-3")
            .QuerySelector(".bc-list")
            .QuerySelectorAll("li");

          foreach (var item in items)
          {
            var audibleMediaItem = audibleSearchResultScraper.Scrape(item);

            yield return audibleMediaItem;
          }
          
          var nextLink = document
            ?.QuerySelector(".linkListWrapper")
            ?.QuerySelector(".pagingElements")
            ?.QuerySelector(".nextButton")
            ?.QuerySelector("button");

          if (nextLink != null)
          {
            var nextLinkRelative = nextLink
              .GetAttribute("data-url");

            currentUrl = "https://www.audible.com" + nextLinkRelative;
          }
          else
          {
            currentUrl = null;
          }
        }
      }
    }
  }
}