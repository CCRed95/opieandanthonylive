using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using Ccr.Dnc.Core.Extensions;
using opieandanthonylive.Common.Scraping;
using opieandanthonylive.Data.Domain.Audible;

namespace opieandanthonylive.Data.API.Audible.Scraping
{
  public class AudibleSearchResultScraper
    : SearchResultScraper<AudibleMediaItem>
  {
    private static readonly Regex _ratingsCountRegex = new Regex(
      @"(?<count>[\d]*) rating[s]?");

    private static readonly Regex _ratingsAverageRegex = new Regex(
      @"(?<rating>[0-9.]*) out of 5 stars");


    private static readonly Dictionary<string, MetadataRouterBase> metadataSelectorMapping
      = new Dictionary<string, MetadataRouterBase>
      {
        ["authorLabel"] = new MetadataRouter<string>(
          span => span.QuerySelector("a").TextContent.Trim(),
          t => t.By),

        ["narratorLabel"] = new MetadataRouter<string>(
          span => span.QuerySelector("a").TextContent.Trim(),
          t => t.NarratedBy),

        ["runtimeLabel"] = new MetadataRouter<TimeSpan>(
          span => AudibleTimeSpanParser.Parse(span.TextContent),
          t => t.PlaybackLength),

        ["releaseDateLabel"] = new MetadataRouter<DateTime>(
          span => DateTime.Parse(span.TextContent.Replace("Release date:", "").Trim()),
          t => t.ReleaseDate)
      };


    public override AudibleMediaItem Scrape(
      IElement node)
    {
      var metadataContainer = node
        .QuerySelector(".bc-row-responsive")
        .QuerySelector(".bc-col-responsive")
        .QuerySelector(".bc-row-responsive")
        .Children[1]
        .QuerySelector(".bc-row-responsive")
        .QuerySelector(".bc-col-responsive")
        .QuerySelector("span")
        .QuerySelector("ul");


      var ratingsData = ReadRatingsData(metadataContainer);

      var audibleItemMetadata = new AudibleMediaItem
      {
        Title = ReadTitle(metadataContainer),
        FullShowMetadataUrl = ReadItemUrl(metadataContainer),
        NumberOfRatings = ratingsData.numberOfRatings,
        AverageRating = ratingsData.averageRating
      };

      metadataContainer
        .QuerySelectorAll("li")
        .ForEach(t =>
        {
          var metadataKinds = t
            .ClassList
            .ToList();

          metadataKinds.Remove(
            "bc-list-item");

          if (metadataKinds.Count == 1)
          {
            var metadataKind = metadataKinds[0];

            if (metadataKind != "ratingsLabel")
            {
              if (!metadataSelectorMapping.TryGetValue(metadataKind, out var metadataMapping))
                throw new NotSupportedException(
                  $"Cannot find key {metadataKind.Quote()} in the Metadata Selector Mapping " +
                  $"dictionary, so it is not supported.");

              var metadataValue = metadataMapping.ScrapeBase(t.Children[0]);

              metadataMapping.ExecutePropertySetBase(
                audibleItemMetadata,
                metadataValue);
            }
          }
        });

      return audibleItemMetadata;
    }
    
    protected string ReadTitle(
      IElement metadataContainer)
    {
      return "";
      return metadataContainer
        .QuerySelector(".adbl-prod-title")
        .QuerySelector("a")
        .TextContent;
    }

    protected string ReadItemUrl(
      IElement metadataContainer)
    {
      return "";
      return metadataContainer
        .QuerySelector(".adbl-prod-title")
        .QuerySelector("a")
        .GetAttribute("href");
    }



    protected (int numberOfRatings, double? averageRating) ReadRatingsData(
      IElement metadataContainer)
    {
      var numberOfRatings = ReadRatingsCount(metadataContainer);

      var averageRating = numberOfRatings > 0
        ? ReadAverageRating(metadataContainer)
        : null;

      return (numberOfRatings, averageRating);
    }

    protected int ReadRatingsCount(
      IElement metadataContainer)
    {
      var ratingsCountSpan = metadataContainer
        ?.QuerySelectorAll(".bc-text")
        ?.Last();

      if (ratingsCountSpan == null)
        return 0;

      var ratingsText = ratingsCountSpan
        .TextContent
        .Trim();

      if (!_ratingsCountRegex.IsMatch(ratingsText))
        return 0;

      var ratingsCountStr = _ratingsCountRegex
        .Match(ratingsText)
        .Groups["count"];

      return int.Parse(
        ratingsCountStr.Value);
    }

    protected double? ReadAverageRating(
      IElement metadataContainer)
    {
      var ratingsAverageSpan = metadataContainer
        ?.QuerySelector(".ratingsLabel")
        ?.QuerySelector(".bc-pub-offscreen");

      if (ratingsAverageSpan == null)
        return 0;
      
      var averageRatingsStr = ratingsAverageSpan
        .TextContent
        .Trim();

      if (!_ratingsAverageRegex.IsMatch(averageRatingsStr))
        return null;

      var ratingsCountStr = _ratingsAverageRegex
        .Match(averageRatingsStr)
        .Groups["rating"];
      
      return double.Parse(
        ratingsCountStr.Value);
    }
  }
}
