using System;
using Ccr.Std.Core.Extensions;
using opieandanthonylive.Data.API.Common.Query;
using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Data.API.Patreon.Query
{
	public class PatreonQueryBuilder
		: IPatreonQueryBuilder,
			IQueryBuilder
	{
		internal const string defaultAuthKey = "Bo8GgGQjHgf4uM7eddUKBMEeYh4S7qhm";

		private string _creatorName;
		private string _authKey;


		public string CreatorName
		{
			get => _creatorName;
			internal set => _creatorName = value;
		}

		public string AuthKey
		{
			get => _authKey;
			internal set => _authKey = value;
		}


		public string BuildRequestUrl(
			DomainFragment requestBuilder)
		{
			var uriBuilder = requestBuilder
				.Builder
				.WithPath("rss/");

			if (_creatorName == null)
				throw new NotSupportedException(
					$"Cannot build the request Url from the DomainFragment because the backing field " +
					$"{nameof(_creatorName).SQuote()} is null.");
			
			uriBuilder.WithPath(_creatorName);

			if (_authKey == null)
				throw new NotSupportedException(
					$"Cannot build the request Url from the DomainFragment because the backing field " +
					$"{nameof(_authKey).SQuote()} is null.");

			uriBuilder.WithParameter("auth", _authKey);

			return uriBuilder.Build();
		}
	}
}
