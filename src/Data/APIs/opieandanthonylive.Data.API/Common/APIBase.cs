using System.Collections.Generic;
using opieandanthonylive.Data.API.Infrastructure;

namespace opieandanthonylive.Common
{
  public abstract class APIBase<TResult>
  {
    protected abstract DomainFragment RequestBuilder { get; }

    public abstract IEnumerable<TResult> Query();
  }
}
