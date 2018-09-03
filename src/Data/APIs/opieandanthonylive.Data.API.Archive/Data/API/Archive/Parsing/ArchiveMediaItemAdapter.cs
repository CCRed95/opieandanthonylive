using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.API.Archive.Parsing
{
  public static class ArchiveMediaItemAdapter
  {
    private static readonly Regex _dateRegex = new Regex(
      @"\A(?<year>[0-9]*)-(?<month>[0-9]*)-(?<day>[0-9]*)");

    private static readonly IDictionary<string, Show> _showPrefixMapping
      = new Dictionary<string, Show>
      {
        ["O&A-"] = Show.OpieAndAnthonyShow,
        ["OA-"] = Show.OpieAndAnthonyShow,

        ["R&F-"] = Show.RonAndFezShow,
        ["RF-"] = Show.RonAndFezShow,

      };

    public static (Show show, DateTime airDate) FromFormat(
      string fileName)
    {
      fileName = ScrapeShow(fileName, out var _show);
      fileName = ScrapeDate(fileName, out var _date);

      return (_show, _date);

    }

    private static string ScrapeShow(
      string fileName, 
      out Show _show)
    {
      foreach (var mapping in _showPrefixMapping)
      {
        mapping.Deconstruct(
          out var prefix,
          out var show);

        if (fileName.Contains(prefix))
        {
          _show = show;
          return fileName.Replace(prefix, "");
        }
      }
      throw new FormatException();
    }


    private static string ScrapeDate(
      string fileName,
      out DateTime _date)
    {
      var match = _dateRegex.Match(fileName);

      var yearStr = match.Groups["year"].Value;
      var monthStr = match.Groups["month"].Value;
      var dayStr = match.Groups["day"].Value;

      var year = int.Parse(yearStr);
      var month = int.Parse(monthStr);
      var day = int.Parse(dayStr);

      var showAirDate = DateTime.Parse(
        $"{year}-{month}-{day}");

      _date = showAirDate;
      return fileName;
    }
  }
}
