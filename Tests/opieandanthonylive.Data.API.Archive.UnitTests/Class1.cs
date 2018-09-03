using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using opieandanthonylive.Data.API.Archive.Interpreters;

namespace opieandanthonylive.Data.API.Archive.UnitTests
{
  [TestFixture]
  public class Class1
  {
    [Test]
    public void CanQuery()
    {
      var archiveAPI = new ArchiveAPI();
      var archiveAlbums = archiveAPI.Query();

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
        Debug.WriteLine($"ArchiveFile");
        Debug.WriteLine($"{{");
        Debug.Indent();

        foreach (var archiveFile in archiveAlbum.ArchiveFiles)
        {
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
        }

        Debug.Unindent();
        Debug.WriteLine($"}}");
        Debug.Unindent();
        Debug.WriteLine($"}}");
        Debug.Unindent();
        Debug.WriteLine($"}}");
      }
    }
  }
}
