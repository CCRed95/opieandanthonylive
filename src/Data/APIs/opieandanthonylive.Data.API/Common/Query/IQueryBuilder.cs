using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Common.Query
{
  public interface IQueryBuilder
  {
    string BuilldRequestUrl(
      DomainFragment requestBuilder);
  }
}