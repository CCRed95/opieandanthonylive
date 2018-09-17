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
}
