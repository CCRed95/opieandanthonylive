using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using opieandanthonylive.Data.API.Common;
using opieandanthonylive.Data.API.Infrastructure;
using opieandanthonylive.Data.API.Patreon.Query;
using opieandanthonylive.Data.Domain.Patreon;

namespace opieandanthonylive.Data.API.Patreon
{
	public class ShoutEngineAPI
		: APIBase<
			ShoutEngineMediaPost,
			ShoutEngineQueryBuilder>
	{
		private const string domainPrefix = "http://";
		private const string domainName = "shoutengine";
		private const string domainSuffix = ".com";

		public static readonly string domain =
			$"{domainPrefix}{domainName}{domainSuffix}";

		private DomainFragment _requestBuilder;


		protected override DomainFragment RequestBuilder
		{
			get => _requestBuilder
				?? (_requestBuilder = new DomainFragment(domain));
		}



		public override IEnumerable<ShoutEngineMediaPost> Query(
			ShoutEngineQueryBuilder queryBuilder)
		{
			var url = queryBuilder.BuildRequestUrl(RequestBuilder);

			var reader = XmlReader.Create(url);
			var feed = SyndicationFeed.Load(reader);
			reader.Close();

			foreach (var syndicationItem in feed.Items)
			{
				var primaryLinks = syndicationItem
					.Links
					.Where(
						t => t.RelationshipType != "alternate")
					.ToArray();

				var primaryLink = primaryLinks.Single();

				yield return new ShoutEngineMediaPost
				{
					Title = syndicationItem.Title.Text,
					Summary = syndicationItem.Summary.Text,
					DateTime = syndicationItem.PublishDate,
					FilePath = primaryLink.GetAbsoluteUri().AbsoluteUri,
				};

				//foreach (var link in syndicationItem.Links)
				//{
				//	var absoluteUri = link.GetAbsoluteUri();

				//}
			}

		}
	}



	public class PatreonAPI
		: APIBase<
			PatreonMediaPost, 
			PatreonQueryBuilder>
	{
		private const string domainPrefix = "https://www.";
		private const string domainName = "patreon";
		private const string domainSuffix = ".com";

		public static readonly string domain =
			$"{domainPrefix}{domainName}{domainSuffix}";

		private DomainFragment _requestBuilder;


		protected override DomainFragment RequestBuilder
		{
			get => _requestBuilder
				?? (_requestBuilder = new DomainFragment(domain));
		}

		public override IEnumerable<PatreonMediaPost> Query(
			PatreonQueryBuilder queryBuilder)
		{
			var url = queryBuilder.BuildRequestUrl(RequestBuilder);

			var reader = XmlReader.Create(url);
			var feed = SyndicationFeed.Load(reader);
			reader.Close();
			
			foreach (var syndicationItem in feed.Items)
			{
				var primaryLinks = syndicationItem
					.Links
					.Where(
						t => t.RelationshipType != "alternate")
					.ToArray();

				var primaryLink = primaryLinks.Single();

				yield return new PatreonMediaPost
				{
					Title = syndicationItem.Title.Text,
					Summary = syndicationItem.Summary.Text,
					DateTime = syndicationItem.PublishDate,
					FilePath = primaryLink.GetAbsoluteUri().AbsoluteUri,
				};

				//foreach (var link in syndicationItem.Links)
				//{
				//	var absoluteUri = link.GetAbsoluteUri();
					
				//}
			}


		}
	}
}
