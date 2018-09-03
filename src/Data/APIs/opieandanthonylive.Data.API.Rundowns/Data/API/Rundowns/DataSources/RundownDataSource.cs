using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp;
using opieandanthonylive.Data.API.Infrastructure;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.API.Rundowns.DataSources
{
  public class RundownDataSource
  {
    private const string domainPrefix = "https://";
    private const string domainName = "struff";
    private const string domainSuffix = ".com";

    public static readonly string domain =
      $"{domainPrefix}{domainName}{domainSuffix}";

    private DomainFragment _requestBuilder;

    protected DomainFragment RequestBuilder
    {
      get => _requestBuilder
             ?? (_requestBuilder
               = new DomainFragment(
                 domain));
    }

    private readonly string _serverFileName;

    public ShowRundownAuthor ShowRundownAuthor { get; }

    public Url SourceStartPage
    {
      get
      {
        var url = RequestBuilder
          .Builder
          .WithPath("vbulletin")
          .WithPath("forumdisplay.php")
          .WithPath(_serverFileName)
          .Build();

        return new Url(url);
      }
    }

    public RundownDataSource(
      ShowRundownAuthor showRundownAuthor,
      string serverFileName)
    {
      ShowRundownAuthor = showRundownAuthor;
      _serverFileName = serverFileName;
    }
  }

  public class RundownDataSources
  {
    public static RundownDataSource MelindaRundowns
      = new RundownDataSource(
        ShowRundownAuthor.Melinda, 
        "61-Mellinda-s-Old-O-amp-A-Rundowns");

    public static RundownDataSource HappyTypingGirlRundowns
      = new RundownDataSource(
        ShowRundownAuthor.Happy_Typing_Girl,
        "44-Happytypinggirl-s-old-Rundowns-amp-Recaps");

    public static RundownDataSource StruffRundowns
      = new RundownDataSource(
        ShowRundownAuthor.Struff,
        "49-Struff-s-old-Recaps-amp-Rundowns");



    public static IEnumerable<RundownDataSource> RundownDataSourceList
    {
      get => new[]
      {
        MelindaRundowns,
        HappyTypingGirlRundowns,
        StruffRundowns
      };
    }
  }
}
