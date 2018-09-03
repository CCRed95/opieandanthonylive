using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opieandanthonylive.Data.API.Rundowns;

namespace opieandanthonylive.Data.API.Rundows.Tests
{
  [TestClass]
  public class RundownsAPITests
  {
    [TestMethod]
    public void CanQueryFilesFromRundownsAPI()
    {
      var rundownsAPI = new RundownsAPI();
      var rundownEntries = rundownsAPI.Query().Take(5);

      foreach (var rundownEntry in rundownEntries)
      {

      }
    }
  }
}
