using System.Diagnostics;
using System.Linq;
using Ccr.Dnc.Data.EntityFrameworkCore;
using Ccr.Dnc.Data.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opieandanthonylive.Data.API.Archive;
using opieandanthonylive.Data.Context;
using opieandanthonylive.Data.Domain.Archive;

namespace UnitTestProject1
{
  [TestClass]
  public class Class1
  {
    [TestMethod]
    public void CanQuery()
    {


      //using (var s = new CoreContext())
      //{
      //  s.EnsureSeed();
      //  s.SaveChanges();
      //}

      //using (var UoW = new UnitOfWork<CoreContext>())
      //{
      //  var archiveAlbumRepositories = UoW.GetRepository<ArchiveAlbum, int>();

      //  archiveAlbumRepositories.InsertAll(archiveAlbums);

      //  UoW.Save();
      //}
      var archiveAPI = new ArchiveAPI();
      var archiveAlbums = archiveAPI.Query().Take(5);

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

    //[TestClass]
    //public class UnitTest1
    //{
    //    [TestMethod]
    //    public void TestMethod1()
    //    {
    //      var archiveAPI = new ArchiveAPI();
    //      var searchResults = archiveAPI.Search();

    //      foreach (var searchResult in searchResults)
    //      {
    //        Debug.WriteLine("");
    //        Debug.WriteLine("______________________________________________");
    //        Debug.WriteLine($"ContentCreator: {searchResult.ContentCreator.ContentCreatorName}");
    //        Debug.WriteLine($"DatePublished:  {searchResult.DatePublished}");
    //        Debug.WriteLine($"YearNumber:     {searchResult.YearNumber}");
    //        Debug.WriteLine($"MonthNumber:    {searchResult.MonthNumber}");
    //        Debug.WriteLine($"Description:    {searchResult.Description}");
    //        Debug.WriteLine($"Identifier:     {searchResult.Identifier}");
    //        Debug.WriteLine($"Url:            {searchResult.Identifier}");

    //        Debug.Indent();
    //        Debug.Indent();

    //        var archiveFiles = ArchiveFileInterpreter
    //          .ScrapeArchiveFile(
    //            searchResult)
    //          .ToArray();

    //        foreach (var mediaFile in archiveFiles)
    //        {

    //          Debug.WriteLine($"FileName:      {mediaFile.FileName}");
    //          Debug.WriteLine($"FileTypeInfo:  {mediaFile.FileTypeInfo.Extension}");
    //          Debug.WriteLine($"Show:          {mediaFile.Show?.ShowName}");
    //          Debug.WriteLine($"Album:         {mediaFile.Album?.Identifier}");
    //          Debug.WriteLine($"Identifier:    {mediaFile.Identifier}");
    //          Debug.WriteLine($"Title:         {mediaFile.Title}");
    //          Debug.WriteLine($"LastModDate:   {mediaFile.LastModifiedDate}");
    //          Debug.WriteLine($"Bytes:         {mediaFile.ApproximateBytes}");
    //        }

    //        Debug.Unindent();
    //        Debug.Unindent();
    //      }
    //}
    //}
  }
}
