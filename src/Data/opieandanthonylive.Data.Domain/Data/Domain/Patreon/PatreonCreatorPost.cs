using System;

namespace opieandanthonylive.Data.Domain.Patreon
{
	public class PatreonMediaPost
	{
		public int PatreonMediaPostID { get; set; }

		public string Title { get; set; }

		public string Summary { get; set; }

		public string Body { get; set; }
		
		public DateTimeOffset DateTime { get; set; }

		public string FilePath { get; set; }
	}

	//public class PatreonCreatorPost
	// {
	//   public int PatreonCreatorPostID { get; set; }

	//   public DateTime PostDateTime { get; set; }

	//   public string PostTitle { get; set; }

	//   public string PostBody { get; set; }
	// }
}
