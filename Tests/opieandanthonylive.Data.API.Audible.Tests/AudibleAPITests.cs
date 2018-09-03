using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace opieandanthonylive.Data.API.Audible.Tests
{
  [TestClass]
  public class AudibleAPITests
  {
    [TestMethod]
    public void CanQueryFilesFromAudibleAPI()
    {
      var archiveAPI = new AudibleAPI();
      var archiveAlbums = archiveAPI.Query().Take(5);


      foreach (var archiveItem in archiveAlbums)
      {

      }


    }
  }
}
