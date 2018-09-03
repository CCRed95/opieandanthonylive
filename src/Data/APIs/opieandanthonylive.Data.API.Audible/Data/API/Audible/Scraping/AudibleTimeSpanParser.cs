using System;
using System.Text.RegularExpressions;

namespace opieandanthonylive.Data.API.Audible.Scraping
{
  internal static class AudibleTimeSpanParser
  {
    private static readonly Regex _timeSpanHrRegex = new Regex(
      @"(?<value>[\d]*)?[ ]?hr[s]?");

    private static readonly Regex _timeSpanMinRegex = new Regex(
      @"(?<value>[\d]*) min[s]?");


    public static TimeSpan Parse(string str)
    {
      int getIntValue(Regex regex)
      {
        if (!regex.IsMatch(str))
          return 0;

        var match = regex.Match(str);
        var valueStr = match.Groups["value"].Value;

        return int.Parse(valueStr);
      }

      var hours = getIntValue(_timeSpanHrRegex);
      var mins = getIntValue(_timeSpanMinRegex);

      return new TimeSpan(hours, mins, 0);
    }
  }
}