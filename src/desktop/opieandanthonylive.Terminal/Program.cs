using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Ccr.Std.Core.Extensions;
using opieandanthonylive.Terminal.Media.Metadata;

namespace opieandanthonylive.Terminal
{
	public class CumtownShowMetadata
	{
		public int ShowID { get; set; }

		public string Title { get; set; }

		public string Summary { get; set; }

		public DateTime DateTime { get; set; }

		public string FilePathLink { get; set; }
	}

	public class Program
	{
		private static readonly Regex _fileNameRegex
			= new Regex(
				@"(?<year>[\d]*)-(?<month>[\d]*)-(?<day>[\d]*)-(?<showKind>[F|P])");


		private static readonly Regex _titleRegex
			= new Regex(
				@"Ep. (?<epNumber>[0-9]*) - Ep. (?<epNumber2>[0-9]*) - (?<title>[^\\z]*)");


		private static readonly Regex _logFileRegex
			= new Regex(
				@" - Title:     (?<title>[^\r]*)\r\n   Summary:   (?<summaryLine1>[^\r]*)\r\n[\s]*((?<summaryLine2>[^\r]*)\r\n[\s]*)?((?<summaryLine3>[^\r]*)\r\n[\s]*)?((?<summaryLine4>[^\r]*)\r\n[\s]*)?((?<summaryLine5>[^\r]*)\r\n[\s]*)?((?<summaryLine6>[^\r]*)\r\n[\s]*)?DateTime:  (?<month>[0-9]*)/(?<day>[0-9]*)/(?<year>[0-9]*) (?<hour>[0-9]*):(?<min>[0-9]*) (?<timeOfDay>[A|P]M?)\r\n   FilePath:  (?<filePathLink>[^\r]*)\r\n");

		private static readonly Regex _fileTitleRegex
			= new Regex(
				@"Ep. (?<epNumber>[0-9]*) - (?<title>[^\\z]*)");

		//
		public static void Main(string[] args)
		{
			//var dir = new DirectoryInfo(@"C:\Cumtown\");
			//var files = dir.EnumerateFiles("*", SearchOption.AllDirectories);

			//var premiumCount = 1;
			//var freeCount = 1;

			var s = ReadCumtownShowMetadataFile(@"C:\Cumtown\shows.txt");//.ToArray();

			foreach (var show in s)
			{
				var match = _fileTitleRegex.Match(show.Title);

				var epNumber = int.Parse(match.Groups["epNumber"].Value);

				var title = match.Groups["epNumber"].Value;

				Console.WriteLine(
					$"<ShowMediaEntry\r\n" +
					$"	x:Key=\"CT\"\r\n" +
					$"	ShowNumber={epNumber.ToString().Quote()}\r\n" +
					$"	ShowID=\"7\"\r\n" +
					$"	EmbeddedContentSourceUrl={show.FilePathLink.Quote()}\r\n" +
					$"	EmbeddedContentSourceID=\"4\"\r\n" +
					$"	AirDate=\"{show.DateTime:u}\"\r\n" +
					$"	Title={title.Quote()}\r\n" +
					$"	Subtitle={show.Summary.Quote()}\\>");
			}
		}

		public static void old(
				string[] args)
			{

				var dir = new DirectoryInfo(@"C:\Cumtown\");
			var files = dir.EnumerateFiles("*", SearchOption.AllDirectories);

			var premiumCount = 1;
			var freeCount = 1;

			foreach (var file in files.OrderBy(t => t.Name))
			{
				if (!_fileNameRegex.IsMatch(file.Name))
					continue;

				var match = _fileNameRegex.Match(file.Name);
				var showKind = match.Groups["showKind"].Value;

				var year = int.Parse(match.Groups["year"].Value);
				var month = int.Parse(match.Groups["month"].Value);
				var day = int.Parse(match.Groups["day"].Value);

				var audioShellObject = new AudioShellObject(file);
				var showKindName = "?";

				var currentCount = 0;
				if (showKind == "P")
				{
					showKindName = "Premium";
					currentCount = premiumCount;
					premiumCount++;
				}
				else if (showKind == "F")
				{
					showKindName = "Free";
					currentCount = freeCount;
					freeCount++;
				}
				else
				{
					throw new Exception();
				}

				var oldTitle = audioShellObject.Title;

				if (!_titleRegex.IsMatch(oldTitle))
				{

				}
				var match2 = _titleRegex
					.Match(oldTitle);
				
				var epNumber = int.Parse(match2.Groups["epNumber"].Value);
				var title = match2.Groups["title"].Value;

				audioShellObject.Title =
					$"Cumtown - Ep. {epNumber:000} [{showKind}] - {title}";
					//$"Cumtown - Ep. {currentCount:000} ({showKindName}) - {year:0000}-{month:00}-{day:00}";

				//audioShellObject.ContentDistributor = "opieandanthonylive";

				audioShellObject.TrackNumber = currentCount;

				audioShellObject.EncodedBy = "CCRed95";

				audioShellObject.ContributingArtists = new[]{"Cumtown"};
				//audioShellObject.Description =
				//	$"Cumtown - Ep. {currentCount:000} ({showKindName}) - {year:0000}-{month:00}-{day:00}";

				//var sb = new StringBuilder();
				//sb.Append(dir.FullName);
				//sb.Append($@"\{year:0000}\{month:00}");

				//sb.Append(
				//	$@"\CT-{year:0000}-{month:00}-{day:00}-{showKind}{file.Extension}");

				//var newPath = sb.ToString();

				//try
				//{
				//	file.MoveTo(newPath);
				//}
				//catch (Exception e)
				//{

				//}
			}

			//var hasStarted = false;

			//var shoutEngineAPI = new ShoutEngineAPI();
			//var queryBuilder = new ShoutEngineQueryBuilder()
			//	.FromCreator("cumtown");

			//var shoutEngineItems = shoutEngineAPI
			//	.Query(queryBuilder); //.Take(5);

			//foreach (var shoutEngineItem in shoutEngineItems)
			//{
			//	Console.WriteLine($"ShoutEngine - Title:     {shoutEngineItem.Title}");
			//	Console.WriteLine($"              Summary:   {shoutEngineItem.Summary}");
			//	Console.WriteLine($"              DateTime:  {shoutEngineItem.DateTime:g}");
			//	Console.WriteLine($"              FilePath:  {shoutEngineItem.FilePath}");
			//	Console.WriteLine();

			//	var create = new WebClient();

			//	var directoryInfo = new DirectoryInfo(
			//		$@"C:\Cumtown\{shoutEngineItem.DateTime.Year:0000}\{shoutEngineItem.DateTime.Month:00}\");

			//	if (!directoryInfo.Exists)
			//		directoryInfo.Create();

			//	var startIndex = shoutEngineItem.FilePath.LastIndexOf('.');
			//	var extentionText = shoutEngineItem.FilePath.Substring(startIndex + 1);

			//	if (hasStarted)
			//	{
			//		var fileText = $@"CTF-{shoutEngineItem.DateTime.Year:0000}-{shoutEngineItem.DateTime.Month
			//			:00}-{shoutEngineItem.DateTime.Day:00}.{extentionText}";

			//		create.DownloadFile(
			//			shoutEngineItem.FilePath,
			//			directoryInfo.FullName + fileText);
			//	}
			//	else if (shoutEngineItem.DateTime.Year <= 2017)
			//	{
			//		if (shoutEngineItem.DateTime.Month <= 7)
			//		{
			//			if (shoutEngineItem.DateTime.Day <= 6)
			//			{
			//				hasStarted = true;

			//				var fileText = $@"CTX-{shoutEngineItem.DateTime.Year:0000}-{
			//						shoutEngineItem.DateTime.Month:00}-{shoutEngineItem.DateTime.Day:00}.{
			//						extentionText
			//					}";

			//				create.DownloadFile(
			//					shoutEngineItem.FilePath,
			//					directoryInfo.FullName + fileText);
			//			}
			//		}
			//	}
			//}
		}

		private static string CleanSummaryLine(string summaryLine)
		{
			return summaryLine
				.Replace("\r", "")
				.Replace("\n", "")
				.Replace("  ", " ")
				.Trim(' ', '\t');
		}


		private static IEnumerable<CumtownShowMetadata> ReadCumtownShowMetadataFile(
			string filePath)
		{
			int epcount = 120;
			using (var fileStream = File.OpenRead(filePath))
			{
				using (var streamReader = new StreamReader(fileStream))
				{
					var sb = new StringBuilder();
					var summaryBuilder = new StringBuilder();

					var text = streamReader.ReadLine();
					var exit = false;

					while (text != null)
					{
						if (text == "")
						{
							var fullText = sb.ToString();

							var match = _logFileRegex.Match(fullText);

							var title = match.Groups["title"].Value;

							if (match.Groups["summaryLine1"].Success)
							{
								var cleanLine = CleanSummaryLine(match.Groups["summaryLine1"].Value);
								sb.AppendLine(cleanLine);
								summaryBuilder.Append(cleanLine + " ");
							}
							if (match.Groups["summaryLine2"].Success)
							{
								var cleanLine = CleanSummaryLine(match.Groups["summaryLine2"].Value);
								//var lastChar = cleanLine.Last();
								sb.AppendLine(cleanLine);
								summaryBuilder.Append(cleanLine + " ");
							}
							if (match.Groups["summaryLine3"].Success)
							{
								var cleanLine = CleanSummaryLine(match.Groups["summaryLine3"].Value);
								sb.AppendLine(cleanLine);
								summaryBuilder.Append(cleanLine + " ");
							}
							if (match.Groups["summaryLine4"].Success)
							{
								var cleanLine = CleanSummaryLine(match.Groups["summaryLine4"].Value);
								sb.AppendLine(cleanLine);
								summaryBuilder.Append(cleanLine + " ");
							}
							if (match.Groups["summaryLine5"].Success)
							{
								var cleanLine = CleanSummaryLine(match.Groups["summaryLine5"].Value);
								sb.AppendLine(cleanLine);
								summaryBuilder.Append(cleanLine + " ");
							}
							if (match.Groups["summaryLine6"].Success)
							{
								var cleanLine = CleanSummaryLine(match.Groups["summaryLine6"].Value);
								sb.AppendLine(cleanLine);
								summaryBuilder.Append(cleanLine + " ");
							}

							var year = int.Parse(match.Groups["year"].Value);
							var month = int.Parse(match.Groups["month"].Value);
							var day = int.Parse(match.Groups["day"].Value);
							var hour = int.Parse(match.Groups["hour"].Value);
							var min = int.Parse(match.Groups["min"].Value);
							var timeOfDay = match.Groups["timeOfDay"].Value;
							var filePathLink = match.Groups["filePathLink"].Value;

							var dateTimeString = $"{month}/{day}/{year} {hour}:{min:00} {timeOfDay}";
							var dateTime = DateTime.Parse(dateTimeString);

							var meta =  new CumtownShowMetadata
							{
								ShowID = epcount,
								DateTime = dateTime,
								Title = title,
								Summary = summaryBuilder.ToString(),
								FilePathLink = filePathLink
							};
							yield return meta;

							sb = new StringBuilder();
							summaryBuilder = new StringBuilder();
							epcount--;
							if (epcount <= 0)
								epcount = 141;

							text = streamReader.ReadLine();
						}
						else
						{
							sb.AppendLine(text);
							text = streamReader.ReadLine();
						}
					}
				}
			}
		}


		//	public static void Main(string[] args)
		//	{
		//		var patreonAPI = new PatreonAPI();

		//		var queryBuilder = new PatreonQueryBuilder()
		//			.FromCreator("cumtown")
		//			.WithDefaultAuthKey();

		//		var patreonItems = patreonAPI
		//			.Query(queryBuilder);//.Take(5);

		//		foreach (var patreonItem in patreonItems)
		//		{
		//			Console.WriteLine($"PatreonPost - Title:     {patreonItem.Title}");
		//			Console.WriteLine($"              Summary:   {patreonItem.Summary}");
		//			Console.WriteLine($"              DateTime:  {patreonItem.DateTime:g}");
		//			Console.WriteLine($"              FilePath:  {patreonItem.FilePath}");
		//			Console.WriteLine();

		//			var create = new WebClient();

		//			var directoryInfo = new DirectoryInfo(
		//				$@"C:\Cumtown\{patreonItem.DateTime.Year:0000}\{patreonItem.DateTime.Month:00}\");

		//			if (!directoryInfo.Exists)
		//				directoryInfo.Create();

		//			create.DownloadFile(
		//				patreonItem.FilePath, 
		//				directoryInfo.FullName +
		//				$@"\CTF-{patreonItem.DateTime.Year:0000}-{patreonItem.DateTime.Month:00}-{patreonItem.DateTime.Day:00}.mp3");
		//			create.
		//		}
		//	}
	}
}
/*				var showType = "?";

				switch (extraChar)
				{
					case null:
					case "":
					{
						showType = "F";
						break;
					}
					case "F":
					{
						showType = "F";
						break;
					}
					case "P":
					{
						showType = "P";
						break;
					}
					case "X":
					{
						showType = "F";
						break;
					}
					default:

						break;
				}
*/
