using System.Linq;
using NUnit.Framework;
using opieandanthonylive.Data.API.Patreon.Query;

namespace opieandanthonylive.Data.API.Patreon.Tests
{
	public class PatreonAPITests
	{
		[Test]
		public void CanQueryFilesFromPatreonAPI()
		{
			var audibleAPI = new PatreonAPI();

			var queryBuilder = new PatreonQueryBuilder()
				.FromCreator("cumtown")
				.WithDefaultAuthKey();

			var audibleItems = audibleAPI
				.Query(queryBuilder)
				.Take(5);

			foreach (var audibleItem in audibleItems)
			{

			}
		}
	}
}