using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opieandanthonylive.Data.API.Archive.Query;
using static opieandanthonylive.Data.API.Archive.Query.ArchiveQueryField;

namespace opieandanthonylive.Data.API.Archive.Tests
{
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

  [TestClass]
  public class ArchiveAPITests
  {
    [TestMethod]
    public void CanQueryFilesFromArchiveAPI()
    {
      var archiveAPI = new ArchiveAPI();

      var queryBuilder = new ArchiveQueryBuilder()
        .WithUploader("opieandanthonylive")
        .WithSubject("Opie and Anthony")
        .WithFields(
          Creator,
          Date,
          Description,
          Identifier,
          MediaType,
          Title)
        .WithSort(
          Title,
          SortDirection.Ascending)
        .WithRows(1000)
        .WithOutputKind(APIDataOutputKind.JSON)
        .WithCallback("callback")
        .WithShouldSave(true);

      var archiveAlbums = archiveAPI
        .Query(queryBuilder)
        .Take(5);

      foreach (var archiveAlbum in archiveAlbums)
      {
        Debug.WriteLine("");
        Debug.WriteLine($"ArchiveAlbum");
        Debug.WriteLine($"{{");
        Debug.Indent();
        Debug.WriteLine($"Identifier:        {archiveAlbum.Identifier}");
        Debug.WriteLine($"ContentCreator:    {archiveAlbum.ContentCreator?.ContentCreatorName}");
        Debug.WriteLine($"Description:       {archiveAlbum.Description}");
        Debug.WriteLine($"DatePublished:     {archiveAlbum.DatePublished}");
        Debug.WriteLine($"YearNumber:        {archiveAlbum.YearNumber}");
        Debug.WriteLine($"MonthNumber:       {archiveAlbum.MonthNumber}");
        Debug.WriteLine($"FileContentsUrl:   {archiveAlbum.AlbumFileContentsUrl}");

        Debug.WriteLine($"{{");
        Debug.Indent();

        foreach (var archiveFile in archiveAlbum.ArchiveFiles)
        {
          Debug.WriteLine($"ArchiveFile");
          Debug.WriteLine($"{{");
          Debug.Indent();

          Debug.WriteLine($"FileName:          {archiveFile.FileName}");
          Debug.WriteLine($"FileTypeInfo:      {archiveFile.ArchiveFileTypeInfo?.Extension}");
          Debug.WriteLine($"Show:              {archiveFile.Show?.ShowName}");
          Debug.WriteLine($"Album:             {archiveFile.ArchiveAlbum?.Identifier}");
          Debug.WriteLine($"ShowRundown:       {archiveFile.ShowRundown?.ShowRundownID}");
          Debug.WriteLine($"Identifier:        {archiveFile.Identifier}");
          Debug.WriteLine($"FilePathUrl:       {archiveFile.FilePathUrl}");
          Debug.WriteLine($"AirDate:           {archiveFile.AirDate}");
          Debug.WriteLine($"Title:             {archiveFile.Title}");
          Debug.WriteLine($"LastModifiedDate:  {archiveFile.LastModifiedDate}");
          Debug.WriteLine($"Bytes:             {archiveFile.ApproximateBytes}");

          Debug.Unindent();
          Debug.WriteLine($"}}");
        }

        Debug.Unindent();
        Debug.WriteLine($"}}");

        Debug.Unindent();
        Debug.WriteLine($"}}");
      }
    }
  }
}
