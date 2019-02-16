using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opieandanthonylive.Data.API.Audible.Query;
using opieandanthonylive.Data.API.Common.Query;
using static opieandanthonylive.Data.API.Audible.Query.AudibleQueryField;

namespace opieandanthonylive.Data.API.Audible.Tests
{
  /*
   *.WithPath("search/")
        .WithPath("ref=sr_sort_publication_date")
        .WithParameter("searchAuthor", "Opie+Anthony")
        .WithParameter("searchRank", "publication_date")
        .WithParameter("field_language", "9178177011")
        .WithParameter("searchSize", "20")
        .WithParameter("searchRankSelect", "-publication_date")
   */

  [TestClass]
  public class AudibleAPITests
  {
    [TestMethod]
    public void CanQueryFilesFromAudibleAPI()
    {
      var audibleAPI = new AudibleAPI();
      var queryBuilder = new AudibleQueryBuilder()
        .WithSort(
          Publication_Date,
          SortDirection.Ascending)
        .WithAuthor("Opie+Anthony")
        .WithSearchRank(Publication_Date)
        .WithFieldLanguage(AudibleFieldLanguage.English)
        .WithSearchSize(20)
        .WithSearchRankSelect(
          Publication_Date,
          SortDirection.Descending);

      var audibleItems = audibleAPI
				.Query(queryBuilder)
        .Take(5);


      foreach (var audibleItem in audibleItems)
      {

      }
    }
  }
}
