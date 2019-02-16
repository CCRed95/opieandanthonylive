using opieandanthonylive.Data.API.Patreon;
using opieandanthonylive.Data.API.Patreon.Query;
using opieandanthonylive.Data.Domain.Patreon;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace opieandanthonylive.Terminal.Commands.Data.Services
{
	public class ShoutEngineDataServiceCommands
	{

	}

	public class PatreonDataServiceCommands
	{
		public IEnumerable<PatreonMediaPost> Query(
			string creatorName)
		{
			var patreonAPI = new PatreonAPI();
			var queryBuilder = new PatreonQueryBuilder()
				.FromCreator("cumtown")
				.WithDefaultAuthKey();

			var patreonItems = patreonAPI
				.Query(queryBuilder);

			foreach (var patreonItem in patreonItems)
			{
				Debug.WriteLine($"\"ShowMediaItem\": {{");
				Debug.WriteLine($"  \"Source\":		\"patreon\",");
				Debug.WriteLine($"  \"Title\":		{patreonItem.Title},");
				Debug.WriteLine($"  \"Summary\":	{patreonItem.Summary},");
				Debug.WriteLine($"  \"DateTime\":	{patreonItem.DateTime:g},");
				Debug.WriteLine($"  \"FilePath\":	{patreonItem.FilePath}");
				Debug.WriteLine($"}},");
				Debug.WriteLine("");

				yield return patreonItem;

				var create = new WebClient();

				var directoryInfo = new DirectoryInfo(
					$@"C:\Cumtown\{patreonItem.DateTime.Year:0000}\{patreonItem.DateTime.Month:00}\");

				if (!directoryInfo.Exists)
					directoryInfo.Create();

				create.DownloadFile(
					patreonItem.FilePath,
					directoryInfo.FullName +
					$@"\CTF-{patreonItem.DateTime.Year:0000}-{patreonItem.DateTime.Month:00}-{patreonItem.DateTime.Day:00}.mp3");
				//create.
			}
		}


		public static void WriteToLog(
			PatreonMediaPost post)
		{
			var str =
				@"""ShowMediaItem"" ";
			Debug.WriteLine($"\"ShowMediaItem\": {{");
			Debug.WriteLine($"  \"Source\":		\"patreon\",");
			Debug.WriteLine($"  \"Title\":		{post.Title},");
			Debug.WriteLine($"  \"Summary\":	{post.Summary},");
			Debug.WriteLine($"  \"DateTime\":	{post.DateTime:g},");
			Debug.WriteLine($"  \"FilePath\":	{post.FilePath}");
			Debug.WriteLine($"}},");


			Debug.WriteLine($"\"ShowMediaItem\": {{");
			Debug.WriteLine($"  \"Source\":		\"patreon\",");
			Debug.WriteLine($"  \"Title\":		{post.Title},");
			Debug.WriteLine($"  \"Summary\":	{post.Summary},");
			Debug.WriteLine($"  \"DateTime\":	{post.DateTime:g},");
			Debug.WriteLine($"  \"FilePath\":	{post.FilePath}");
			Debug.WriteLine($"}},");
			Debug.WriteLine("");
		}
		//{
		//	var patreonAPI = new PatreonAPI();
		//	var queryBuilder = new PatreonQueryBuilder()
		//		.FromCreator("cumtown")
		//		.WithDefaultAuthKey();

		//	var patreonItems = patreonAPI
		//		.Query(queryBuilder);

		//	foreach (var patreonItem in patreonItems)
		//	{


		//		yield return patreonItem;

		//		var create = new WebClient();

		//		var directoryInfo = new DirectoryInfo(
		//			$@"C:\Cumtown\{patreonItem.DateTime.Year:0000}\{patreonItem.DateTime.Month:00}\");

		//		if (!directoryInfo.Exists)
		//			directoryInfo.Create();

		//		create.DownloadFile(
		//			patreonItem.FilePath,
		//			directoryInfo.FullName +
		//			$@"\CTF-{patreonItem.DateTime.Year:0000}-{patreonItem.DateTime.Month:00}-{patreonItem.DateTime.Day:00}.mp3");
		//		//create.
		//	}
		//}
	}
}
