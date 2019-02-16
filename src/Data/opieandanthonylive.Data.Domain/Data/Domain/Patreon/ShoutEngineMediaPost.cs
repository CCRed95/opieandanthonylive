using System;

namespace opieandanthonylive.Data.Domain.Patreon
{
	public class ShoutEngineMediaPost
	{
		public int ShoutEngineMediaPostID { get; set; }

		public string Title { get; set; }

		public string Summary { get; set; }

		public string Body { get; set; }

		public DateTimeOffset DateTime { get; set; }

		public string FilePath { get; set; }
	}
}