using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opieandanthonylive.Data.API.Archive.Query;
using opieandanthonylive.Data.API.Web;
using System.Diagnostics;
using System.IO;
using System.Net;
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
				.WithSubject("Ron and Fez")
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
				.Query(queryBuilder);

			foreach (var archiveAlbum in archiveAlbums)
			{
				if (archiveAlbum.YearNumber <= 2005)
				{
					if (!((archiveAlbum.YearNumber == 2005) && (archiveAlbum.MonthNumber > 02)))
					{
						Debug.WriteLine("skipping, done.");

						continue;
					}

				}

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
					if (archiveFile.FileName.EndsWith("mp3"))
					{
						var filePath = archiveFile.FileName.UrlDecode();


						Debug.WriteLine($"MP3 File");
						Debug.WriteLine($"{{");
						Debug.Indent();

						Debug.WriteLine($"FileName:          {archiveFile.FileName}");
						Debug.WriteLine($"LocalFilePathNam:  {filePath}");
						Debug.WriteLine($"Show:              {archiveFile.Show?.ShowName}");
						Debug.WriteLine($"Album:             {archiveFile.ArchiveAlbum?.Identifier}");
						Debug.WriteLine($"Identifier:        {archiveFile.Identifier}");
						Debug.WriteLine($"FilePathUrl:       {archiveFile.FilePathUrl}");
						Debug.WriteLine($"AirDate:           {archiveFile.AirDate}");
						Debug.WriteLine($"Title:             {archiveFile.Title}");
						//Debug.WriteLine($"LastModifiedDate:  {archiveFile.LastModifiedDate}");
						Debug.WriteLine($"Bytes:             {archiveFile.ApproximateBytes} bytes");

						Debug.Unindent();
						Debug.WriteLine($"}}");

						var localPath = $@"D:\ronandfez\{archiveFile.AirDate.Year}\{archiveFile.AirDate.Month:00}\";

						if (!Directory.Exists(localPath))
							Directory.CreateDirectory(localPath);

						Debug.Indent();
						Debug.WriteLine($"[Downloading MP3:]           {archiveFile.FilePathUrl}");
						Debug.WriteLine($"   |- {localPath}{filePath}'");
						using (var webClient = new WebClient())
						{
							webClient.DownloadFile(
								archiveFile.FilePathUrl,
								localPath + filePath);
						}
						Debug.WriteLine($"Download Complete.");

						Debug.Unindent();
					}
				}


				Debug.Unindent();
				Debug.WriteLine($"}}");

				Debug.Unindent();
				Debug.WriteLine($"}}");
			}

			Debug.WriteLine($"Totally complete yo");
		}

		//[TestMethod]
		//public void CanQueryFilesFromArchiveAPI()
		//{
		//	var archiveAPI = new ArchiveAPI();

		//	var queryBuilder = new ArchiveQueryBuilder()
		//		.WithUploader("opieandanthonylive")
		//		.WithSubject("Ron and Fez")
		//		.WithFields(
		//			Creator,
		//			Date,
		//			Description,
		//			Identifier,
		//			MediaType,
		//			Title)
		//		.WithSort(
		//			Title,
		//			SortDirection.Ascending)
		//		.WithRows(1000)
		//		.WithOutputKind(APIDataOutputKind.JSON)
		//		.WithCallback("callback")
		//		.WithShouldSave(true);

		//	var archiveAlbums = archiveAPI
		//		.Query(queryBuilder);

		//	foreach (var archiveAlbum in archiveAlbums)
		//	{
		//		Debug.WriteLine("");
		//		Debug.WriteLine($"ArchiveAlbum");
		//		Debug.WriteLine($"{{");
		//		Debug.Indent();
		//		Debug.WriteLine($"Identifier:        {archiveAlbum.Identifier}");
		//		Debug.WriteLine($"ContentCreator:    {archiveAlbum.ContentCreator?.ContentCreatorName}");
		//		Debug.WriteLine($"Description:       {archiveAlbum.Description}");
		//		Debug.WriteLine($"DatePublished:     {archiveAlbum.DatePublished}");
		//		Debug.WriteLine($"YearNumber:        {archiveAlbum.YearNumber}");
		//		Debug.WriteLine($"MonthNumber:       {archiveAlbum.MonthNumber}");
		//		Debug.WriteLine($"FileContentsUrl:   {archiveAlbum.AlbumFileContentsUrl}");

		//		Debug.WriteLine($"{{");
		//		Debug.Indent();

		//		foreach (var archiveFile in archiveAlbum.ArchiveFiles)
		//		{

		//			Debug.WriteLine($"ArchiveFile");
		//			Debug.WriteLine($"{{");
		//			Debug.Indent();

		//			Debug.WriteLine($"FileName:          {archiveFile.FileName}");
		//			Debug.WriteLine($"FileTypeInfo:      {archiveFile.ArchiveFileTypeInfo?.Extension}");
		//			Debug.WriteLine($"Show:              {archiveFile.Show?.ShowName}");
		//			Debug.WriteLine($"Album:             {archiveFile.ArchiveAlbum?.Identifier}");
		//			Debug.WriteLine($"ShowRundown:       {archiveFile.ShowRundown?.ShowRundownID}");
		//			Debug.WriteLine($"Identifier:        {archiveFile.Identifier}");
		//			Debug.WriteLine($"FilePathUrl:       {archiveFile.FilePathUrl}");
		//			Debug.WriteLine($"AirDate:           {archiveFile.AirDate}");
		//			Debug.WriteLine($"Title:             {archiveFile.Title}");
		//			Debug.WriteLine($"LastModifiedDate:  {archiveFile.LastModifiedDate}");
		//			Debug.WriteLine($"Bytes:             {archiveFile.ApproximateBytes}");

		//			Debug.Unindent();
		//			Debug.WriteLine($"}}");

		//			if (archiveFile.FileName.EndsWith("mp3"))
		//			{
		//				var localPath = $@"C:\Users\Eric\Desktop\R&F\{archiveFile.AirDate.Year}\{
		//					archiveFile.AirDate.Month:00}\";

		//				if (!Directory.Exists(localPath))
		//					Directory.CreateDirectory(localPath);

		//				var filePath = archiveFile.FileName.UrlDecode();

		//				Debug.Indent();
		//				Debug.WriteLine($"[Downloading MP3:]           {archiveFile.FilePathUrl}");
		//				Debug.WriteLine($"                                 to '{filePath}'");
		//				using (var webClient = new WebClient())
		//				{
		//					webClient.DownloadFile(
		//						archiveFile.FilePathUrl,
		//						localPath + filePath);
		//				}
		//				Debug.WriteLine($"Download Complete.");

		//				Debug.Unindent();
		//			}
		//		}


		//		Debug.Unindent();
		//		Debug.WriteLine($"}}");

		//		Debug.Unindent();
		//		Debug.WriteLine($"}}");
		//	}

		//	Debug.WriteLine($"Totally complete yo");
		//}
	}
}
