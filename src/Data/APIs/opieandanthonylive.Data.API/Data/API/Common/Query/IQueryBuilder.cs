using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Data.API.Common.Query
{
  public interface IQueryBuilder
  {
    string BuildRequestUrl(
      DomainFragment requestBuilder);
  }
}