using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using Ccr.Data.EntityFrameworkCore;
using Ccr.Std.Core.Extensions;
using opieandanthonylive.Data.Context;
using opieandanthonylive.Data.Domain;
using opieandanthonylive.Data.Domain.Archive;

namespace opieandanthonylive.Data.API.Rundowns.Materializers
{
  public class ShowRundownMaterializer
  {
    private static readonly Regex _authorAndDateTimeRegex = new Regex(
        @"Started by (?<author>[_A-z0-9]*) on (?<month>[0-9]*)-(?<day>[0-9]*)-(?<year>[0-9]*) (?<hour>[0-9]*):(?<minute>[0-9]*) (?<AmPm>[A|P]M)");
    

    public static ShowRundown MaterializeThreadLevelShowMetadata(
      IElement threadElement)
    {
      var threadTitle = threadElement
        .QuerySelector(".threadinfo")
        .GetAttribute("title");

      var inner = threadElement
        .QuerySelector(".inner");

      var fullThreadLink = inner
        .QuerySelector("a")
        .GetAttribute("href");

      var threadInnerTitle = inner
        .QuerySelector("a")
        .TextContent;

      var authorLabel = inner
        .QuerySelector(".threadmeta")
        .QuerySelector(".author")
        .QuerySelector(".label");

      var authorNameAndPostDate = authorLabel
        .QuerySelector("a")
        .GetAttribute("title");

      var authorPostDateTimeMatch = _authorAndDateTimeRegex
        .Match(authorNameAndPostDate);

      var author = authorPostDateTimeMatch.Groups["author"].Value;

      var month = int.Parse(authorPostDateTimeMatch.Groups["month"].Value);
      var day = int.Parse(authorPostDateTimeMatch.Groups["day"].Value);
      var year = int.Parse(authorPostDateTimeMatch.Groups["year"].Value);
      var hour = int.Parse(authorPostDateTimeMatch.Groups["hour"].Value);
      var minute = int.Parse(authorPostDateTimeMatch.Groups["minute"].Value);
      var AmPm = authorPostDateTimeMatch.Groups["AmPm"].Value;

      if (AmPm.ToLower() == "pm")
        hour += 12;

      var postDate = new DateTime(
        year,
        month,
        day, 
        hour,
        minute,
        0);

      var associatedArchiveMP3File = MaterializeAssociatedArchiveMP3FileForShow(
        postDate,
        Show.OpieAndAnthonyShow);

      if (associatedArchiveMP3File == null)
        throw new NullReferenceException();
      
      return new ShowRundown(
        threadTitle,
        null,
        associatedArchiveMP3File,
        ShowRundownAuthor.Unknown,
        postDate,
        fullThreadLink);
    }

    private static ArchiveFile MaterializeAssociatedArchiveMP3FileForShow(
      DateTime airDate,
      Show show)
    {
      using (var UoW = new UnitOfWork<CoreContext>())
      {
        var archiveFileRepository = UoW.GetRepository<ArchiveFile, int>();

        var filesMatchingAirDate = archiveFileRepository
          .FetchWhere(
            t => t.AirDate == airDate
                 && t.ShowID == show.ShowID
                 && t.ArchiveFileTypeInfo == ArchiveFileTypeInfo.MP3);

        if (filesMatchingAirDate.Count == 0)
          return null;

        if (filesMatchingAirDate.Count >= 2)
          throw new DataException(
            $"There is more than one matching file result with the {nameof(ArchiveFile.AirDate).SQuote()} " +
            $"property is {airDate.ToString("yyyy-MM-dd").SQuote()}, the {nameof(ArchiveFile.Show).SQuote()} " +
            $"property is {show.ShowName.SQuote()}, and the {nameof(ArchiveFileTypeInfo).SQuote()} is " +
            $"{nameof(ArchiveFileTypeInfo.MP3).SQuote()}.");

        return filesMatchingAirDate.Single();
      }
    }


    //var searchResult = threadElement
    //  .GetElementById("posts")
    //  .Children
    //  .First();

    //var author = searchResult
    //  .QuerySelector(".postdetails")
    //  .QuerySelector(".userinfo")
    //  .QuerySelector(".username_container")
    //  .QuerySelector(".username")
    //  .TextContent
    //  .Trim();

    //var title = searchResult
    //  .QuerySelector(".postbody")
    //  .QuerySelector(".title")
    //  .TextContent
    //  .Trim();

    //var blockQuoteContent = searchResult
    //  .QuerySelector(".postbody")
    //  .QuerySelector(".title")
    //  .QuerySelector(".content")
    //  .QuerySelector("div")
    //  .Children
    //  .First()
    //  .InnerHtml;

    //public static ShowRundown MaterializeEntity(
    //  ArchiveFile archiveFile)
    //{
    //  var context = BrowsingContext
    //    .New(
    //      Configuration
    //        .Default
    //        .WithDefaultLoader());

    //  using (var document = context
    //    .OpenAsync(archiveFile.FilePathUrl)
    //    .GetAwaiter()
    //    .GetResult())
    //  {
    //    var searchResult = document
    //      .GetElementById("posts")
    //      .Children
    //      .First();

    //    var author = searchResult
    //      .QuerySelector(".postdetails")
    //      .QuerySelector(".userinfo")
    //      .QuerySelector(".username_container")
    //      .QuerySelector(".username")
    //      .TextContent
    //      .Trim();

    //    var title = searchResult
    //      .QuerySelector(".postbody")
    //      .QuerySelector(".title")
    //      .TextContent
    //      .Trim();

    //    var blockQuoteContent = searchResult
    //      .QuerySelector(".postbody")
    //      .QuerySelector(".title")
    //      .QuerySelector(".content")
    //      .QuerySelector("div")
    //      .Children
    //      .First()
    //      .InnerHtml;

    //    return new ShowRundown(
    //      title,
    //      blockQuoteContent,
    //      archiveFile,
    //      ShowRundownAuthor.CCRed95,
    //      archiveFile.AirDate,
    //      archiveFile.FilePathUrl);
    //  }
    //}
  }
}

/*
    public static ShowRundown CreateShowRundownFromArchiveFile(
      ArchiveFile archiveFile)
    {
      var filePathUrl =
        $"https://www.archive.org/download/{archiveAlbum.Identifier}/";

      var context = BrowsingContext
        .New(
          Configuration
            .Default
            .WithDefaultLoader());

      using (var document = context
        .OpenAsync(filePathUrl)
        .GetAwaiter()
        .GetResult())
      {
      }

      return new ArchiveAlbum(
        ContentCreator.Opie_and_Anthony,
        doc.Date,
        doc.Date.Year,
        doc.Date.Month,
        doc.Description,
        doc.Identifier);
    }*/
