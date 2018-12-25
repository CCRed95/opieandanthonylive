using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp;
using Ccr.Std.Core.Extensions;
using opieandanthonylive.Data.Domain;
using opieandanthonylive.Data.Domain.Archive;

namespace opieandanthonylive.Data.API.Archive.Interpreters
{
  public class ArchiveFileInterpreter
  {
    private const bool _ignoreCare = true;

    private static readonly IDictionary<string, Show> _definedShowPrefixes
      = new Dictionary<string, Show>
      {
        ["O&A-"] = Show.OpieAndAnthonyShow,
        ["OA-"] = Show.OpieAndAnthonyShow,
        ["R&F-"] = Show.RonAndFezShow,
        ["RF-"] = Show.RonAndFezShow,
        ["RGSX-"] = Show.RickyGervaisShowXFM,
        ["RGSP-"] = Show.RickyGervaisShowPodcasts,
        ["RGSH-"] = Show.RickyGervaisShowHBO,
        ["TCWCQ-"] = Show.ToughCrowdWithColinQuinn,
        ["TC-"] = Show.ToughCrowdWithColinQuinn
      };

    private static readonly Regex _dateRegex = new Regex(
      @"(?<year>[0-9]*)-(?<month>[0-9]*)-(?<day>[0-9]*)");


    public static IEnumerable<ArchiveFile> ScrapeArchiveFiles(
      ArchiveAlbum archiveAlbum)
    {
      var context = BrowsingContext
        .New(
          Configuration
            .Default
            .WithDefaultLoader());

      using (var document = context
        .OpenAsync(archiveAlbum.AlbumFileContentsUrl)
        .GetAwaiter()
        .GetResult())
      {
        var maincontent = document
          .GetElementById("maincontent");

        var container = maincontent
          .GetElementsByClassName("container-ia")
          .First();

        var directoryListing = container
          .GetElementsByClassName("download-directory-listing")
          .First();

        var tbody = directoryListing
          .GetElementsByTagName("tbody")
          .First();

        var fileNodeList = tbody
          .GetElementsByTagName("tr")
          .Skip(1);

        foreach (var fileNode in fileNodeList)
        {
          var fileLinkElement = fileNode
            .GetElementsByTagName("td")
            .First()
            .GetElementsByTagName("a")
            .First();

          var fileLinkPath = fileLinkElement
            .GetAttribute("href");

          var fileTitle = fileLinkElement
            .TextContent;

          var fileDate = fileNode
            .GetElementsByTagName("td")
            .Skip(1)
            .First()
            .TextContent;

          var fileSize = fileNode
            .GetElementsByTagName("td")
            .Skip(2)
            .First()
            .TextContent;

          var archiveFileType = DetermineArchiveFileType(fileTitle);

          var show = DetermineArchiveFileShow(fileTitle, out var showKey);
          if (showKey == null)
            continue;

          var postShowStr = fileTitle.Replace(showKey, "");

          var airDate = DetermineArchiveFileAirDate(
              postShowStr)
            .GetValueOrDefault();

          var approximateBytes = DetermineArchiveFileSizeBytes(fileSize);

          if (!DateTime.TryParseExact(
              fileDate,
              "dd-MMM-yyyy ss:mm",
              DateTimeFormatInfo.CurrentInfo,
              DateTimeStyles.None,
              out var lastModifiedDate))
            throw new FormatException(
              $"Cannot parse dateTime from string {fileDate.Quote()}.");

          yield return new ArchiveFile(
            fileLinkPath,
            archiveFileType,
            show,
            archiveAlbum,
            fileLinkPath,
            $"{archiveAlbum.AlbumFileContentsUrl}{fileLinkPath}",
            airDate,
            fileTitle,
            lastModifiedDate,
            approximateBytes);
        }
      }
    }

    public static Show DetermineArchiveFileShow(
      string fileName,
      out string key)
    {
      foreach (var definedShow in _definedShowPrefixes)
      {
        if (fileName.Contains(definedShow.Key))
        {
          key = definedShow.Key;
          return definedShow.Value;
        }
      }
      key = null;
      return null;
    }

    public static DateTime? DetermineArchiveFileAirDate(
      string fileName)
    {
      if (!_dateRegex.IsMatch(fileName))
        return null;

      var match = _dateRegex.Match(fileName);

      var yearStr = match.Groups["year"].Value;
      var monthStr = match.Groups["month"].Value;
      var dayStr = match.Groups["day"].Value;

      var year = int.Parse(yearStr);
      var month = int.Parse(monthStr);
      var day = int.Parse(dayStr);

      try
      {
        return new DateTime(
          year,
          month,
          day);
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    /// <summary>
    ///   Determines the <see cref="ArchiveFileTypeInfo"/> based on the <paramref name="fileName"/> 
    ///   parameter's parsed out file extension.
    /// </summary>
    /// <param name="fileName">
    ///   The file name as a <see cref="string"/>, including the file extension.
    /// </param>
    /// <returns>
    ///   Returns the <see cref="ArchiveFileTypeInfo"/> indicating the file extensions type.
    /// </returns>
    public static ArchiveFileTypeInfo DetermineArchiveFileType(
      string fileName)
    {
      var extension =
        fileName
          .Split('.')
          .Last()
          .Trim()
          .ToUpper();

      switch (extension)
      {
        case "AFPK":
          return ArchiveFileTypeInfo.AFPK;

        case "PNG":
          return ArchiveFileTypeInfo.PNG;

        case "OGG":
          return ArchiveFileTypeInfo.OGG;

        case "TORRENT":
          return ArchiveFileTypeInfo.Torrent;

        case "SQLITE":
          return ArchiveFileTypeInfo.SQLite;

        case "XML":
          return ArchiveFileTypeInfo.XML;

        default:
          return ArchiveFileTypeInfo.Unknown;
      }
    }

    private enum DataSizeUnit
    {
      Byte,
      Kilobyte,
      Megabyte,
      Gigabyte
    }

    /// <summary>
    ///   Identifies the <see cref="DataSizeUnit"/> that corresponds with the string label 
    ///   passed through the <paramref name="labelString"/> parameter.
    /// </summary>
    /// <param name="labelString">
    ///   The <see cref="string"/> label suffix that is the data unit.
    /// </param>
    /// <returns>
    ///   Returns a <see cref="DataSizeUnit"/> enum instance indicating the data unit kind. 
    /// </returns>
    private static DataSizeUnit LabelStringToDataSizeUnit(
      string labelString)
    {
      switch (labelString.ToLower().Trim())
      {
        case "b":
          return DataSizeUnit.Byte;

        case "k":
        case "kb":
          return DataSizeUnit.Kilobyte;

        case "m":
        case "mb":
          return DataSizeUnit.Megabyte;

        case "g":
        case "gb":
          return DataSizeUnit.Gigabyte;

        default:
          throw new FormatException(
            $"{labelString.Quote()} cannot be converted to a DataSizeUnit value.");
      }
    }


    public static double DetermineArchiveFileSizeBytes(
      string formattedSize)
    {
      formattedSize = formattedSize.Trim();

      var hasEncounteredDecimal = false;
      var numericStr = "";
      var labelStr = "";

      foreach (var c in formattedSize)
      {
        if (c.IsDigit())
        {
          if (!labelStr.IsNullOrEmptyEx())
            throw new FormatException(
              $"Cannot have digits after letters/label.");

          numericStr += c;
        }
        else if (c == '.')
        {
          if (hasEncounteredDecimal)
            throw new FormatException(
              $"Cannot have more than one decimal point.");

          hasEncounteredDecimal = true;
          numericStr += c;
        }
        else if (c.IsLetter())
        {
          labelStr += c;
        }
        else if (c.IsWhiteSpace())
        {
        }
        else if (c == ',')
        {
        }
        else
        {
          throw new FormatException(
            $"The character {c.ToString().SQuote()} is not expected.");
        }
      }

      if (!double.TryParse(numericStr, out var numeric))
        throw new FormatException(
          $"{numericStr.Quote()} cannot be parsed to a double.");


      var dataSizeUnit = LabelStringToDataSizeUnit(labelStr);

      switch (dataSizeUnit)
      {
        case DataSizeUnit.Byte:
          return numeric;

        case DataSizeUnit.Kilobyte:
          return numeric * 1024;

        case DataSizeUnit.Megabyte:
          return numeric * 1024 * 1024;

        case DataSizeUnit.Gigabyte:
          return numeric * 1024 * 1024 * 1024;

        default:
          throw new InvalidEnumArgumentException();
      }
    }
  }
}
