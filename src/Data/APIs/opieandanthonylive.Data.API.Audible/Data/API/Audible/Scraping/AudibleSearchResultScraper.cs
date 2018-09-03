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
      @"\((?<count>[\d]*) rating[s]?\)");


    private static readonly Dictionary<string, MetadataRouterBase> metadataSelectorMapping
      = new Dictionary<string, MetadataRouterBase>
      {
        ["By"] = new MetadataRouter<string>(
          span => span.QuerySelector("a").TextContent.Trim(),
          t => t.By),

        ["Narrated By"] = new MetadataRouter<string>(
          span => span.QuerySelector("a").TextContent.Trim(),
          t => t.NarratedBy),

        ["Length: "] = new MetadataRouter<TimeSpan>(
          span => AudibleTimeSpanParser.Parse(span.TextContent),
          t => t.PlaybackLength),

        ["Release Date:"] = new MetadataRouter<DateTime>(
          span => DateTime.Parse(span.TextContent),
          t => t.ReleaseDate)
      };


    public override AudibleMediaItem Scrape(
      IElement node)
    {
      var metadataContainer = node
        .QuerySelector(".adbl-prod-meta-data-cont");

      var ratingsData = ReadRatingsData(metadataContainer);

      var audibleItemMetadata = new AudibleMediaItem
      {
        ItemTypeClassification = ReadItemTypeClassification(metadataContainer),
        Title = ReadTitle(metadataContainer),
        FullShowMetadataUrl = ReadItemUrl(metadataContainer),
        NumberOfRatings = ratingsData.numberOfRatings,
        AverageRating = ratingsData.averageRating
      };

      metadataContainer
        .QuerySelector(".adbl-prod-meta")
        .QuerySelector("ul")
        .QuerySelectorAll("li")
        .Where(t => t.Children.Length == 2)
        .ForEach(t =>
        {
          var metadataKind = t.Children[0].TextContent;
          var metadataMapping = metadataSelectorMapping[metadataKind];
          var metadataValue = metadataMapping.ScrapeBase(t.Children[1]);

          metadataMapping.ExecutePropertySetBase(audibleItemMetadata, metadataValue);
        });
      
      return audibleItemMetadata;
    }
    

    protected string ReadItemTypeClassification(
      IElement metadataContainer)
    {
      return metadataContainer
        .QuerySelector(".adbl-prod-type")
        .TextContent
        .Trim();
    }

    protected string ReadTitle(
      IElement metadataContainer)
    {
      return metadataContainer
        .QuerySelector(".adbl-prod-title")
        .QuerySelector("a")
        .TextContent;
    }

    protected string ReadItemUrl(
      IElement metadataContainer)
    {
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
      var rating_disp = metadataContainer
        .QuerySelector(".adbl-prod-rating")
        .QuerySelector(".rating_disp");

      var ratingsCountText = rating_disp
        .TextContent
        .Trim();

      var ratingsCountStr = _ratingsCountRegex
        .Match(ratingsCountText)
        .Groups["count"];

      return int.Parse(
        ratingsCountStr.Value);
    }

    protected double? ReadAverageRating(
      IElement metadataContainer)
    {
      var averageRatingsStr = metadataContainer
        .QuerySelector(".adbl-prod-rating")
        .QuerySelector(".rating_disp")
        .QuerySelector(".boldrating")
        .TextContent
        .Trim();

      return double.Parse(
        averageRatingsStr);
    }
  }
}
