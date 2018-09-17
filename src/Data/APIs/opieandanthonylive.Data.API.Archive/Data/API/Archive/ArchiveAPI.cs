using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using opieandanthonylive.Common;
using opieandanthonylive.Data.API.Archive.Interpreters;
using opieandanthonylive.Data.API.Archive.Query;
using opieandanthonylive.Data.API.Infrastructure;
using opieandanthonylive.Data.Domain.Archive;
using opieandanthonylive.Data.Domain.Archive.Responses;
using opieandanthonylive.Web;

namespace opieandanthonylive.Data.API.Archive
{
  public class ArchiveAPI
    : APIBase<
      ArchiveAlbum, 
      ArchiveQueryBuilder>
  {
    private const string _domain = "https://www.archive.org/";
    private DomainFragment _requestBuilder;


    protected override DomainFragment RequestBuilder
    {
      get => _requestBuilder
             ?? (_requestBuilder
               = new DomainFragment(
                 _domain));
    }


    public override IEnumerable<ArchiveAlbum> Query(
      ArchiveQueryBuilder queryBuilder)
    {
      var url = queryBuilder
        .BuilldRequestUrl(
          RequestBuilder);
      
      //var url = RequestBuilder
      //  .Builder
      //  .WithPath("advancedsearch.php")
      //  .WithParameter("q", "uploader:opieandanthonylive AND subject:(Opie and Anthony)")
      //  .WithParameter("fl[]", "creator")
      //  .WithParameter("fl[]", "date")
      //  .WithParameter("fl[]", "description")
      //  .WithParameter("fl[]", "identifier")
      //  .WithParameter("fl[]", "mediatype")
      //  .WithParameter("fl[]", "title")
      //  .WithParameter("sort[]", "titleSorter asc")
      //  .WithParameter("rows", "1000")
      //  .WithParameter("page", "1")
      //  .WithParameter("output", "json")
      //  .WithParameter("callback", "callback")
      //  .WithParameter("save", "yes")
      //  .Build();

      using (var httpClient = new HttpClientWrapper())
      {
        var response = httpClient
          .GetContentAsync(url)
          .GetAwaiter()
          .GetResult();

        var formattedResponse = response;
        if (formattedResponse.StartsWith("callback("))
        {
          formattedResponse = formattedResponse
            .Substring("callback(".Length)
            .TrimEnd(')');
        }

        var archiveResponse = JsonConvert
          .DeserializeObject<RootObject>(
            formattedResponse);

        var archiveAlbums = archiveResponse
          .Response
          .Docs
          .Select(
            ArchiveAlbumInterpreter.CreateArchiveAlbum);

        return archiveAlbums;
      }
    }

  }
}