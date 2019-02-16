using System;
using Ccr.Std.Core.Extensions;
using opieandanthonylive.Data.API.Common.Query;
using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Data.API.Patreon.Query
{
	public class ShoutEngineQueryBuilder
		: IShoutEngineQueryBuilder,
			IQueryBuilder
	{
		//internal const string defaultXmlPath = "http://shoutengine.com/CumTown.xml";
		private string _creatorName;
		public string CreatorName
		{
			get => _creatorName;
			internal set => _creatorName = value;
		}
		

		public string BuildRequestUrl(
			DomainFragment requestBuilder)
		{
			if (_creatorName == null)
				throw new NotSupportedException(
					$"Cannot build the request Url from the DomainFragment because the backing field " +
					$"{nameof(_creatorName).SQuote()} is null.");

			var uriBuilder = requestBuilder
				.Builder
				.WithPath($"{_creatorName}.xml");

			return uriBuilder.Build();
		}
	}
}