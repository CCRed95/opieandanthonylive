using System.Collections.Generic;
using opieandanthonylive.Common.Query;
using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Common
{
  public abstract class APIBase<TResult, TQueryBuilder>
    where TQueryBuilder
      : IQueryBuilder
  {
    protected abstract DomainFragment RequestBuilder { get; }


    public abstract IEnumerable<TResult> Query(
      TQueryBuilder queryBuilder);
  }
}
