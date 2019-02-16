using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opieandanthonylive.Data.API.Common.Query;
using opieandanthonylive.Data.API.Rundowns;
using opieandanthonylive.Data.API.Rundowns.Query;

namespace opieandanthonylive.Data.API.Rundows.Tests
{
  [TestClass]
  public class RundownsAPITests
  {
    [TestMethod]
		public void CanQueryFilesFromRundownsAPI()
		{
			var rundownsAPI = new RundownsAPI();
			var queryBuilder = new RundownQueryBuilder();

			var rundownEntries = rundownsAPI.Query(queryBuilder).Take(5);

			foreach (var rundownEntry in rundownEntries)
			{

			}
		}
  }
}
