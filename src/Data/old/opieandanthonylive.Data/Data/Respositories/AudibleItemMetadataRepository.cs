using System;
using System.Collections.Generic;
using System.Linq;
using Ccr.Dnc.Data.EntityFrameworkCore;
using opieandanthonylive.Data.Context;
using opieandanthonylive.Data.Domain.Audible;

namespace opieandanthonylive.Data.Respositories
{
  public interface IAudibleItemMetadataRepository
  {
    AudibleMediaItem Fetch(int id);

    IList<AudibleMediaItem> FetchAll();

    IList<AudibleMediaItem> FetchByAirDate(DateTime date);

    IList<AudibleMediaItem> FetchPaginated(
      int pageNumber,
      int pageSize = 20);
  }

  public class AudibleItemMetadataRepository
    : Repository<AudibleMediaItem, int, CoreContext>,
      IAudibleItemMetadataRepository
  {
    public AudibleItemMetadataRepository(
      CoreContext context) 
        : base(
          context)
    {
    }


    public IList<AudibleMediaItem> FetchByAirDate(
      DateTime date)
    {
      return DBSet
        .Where(t => t.ReleaseDate.Date == date.Date)
        .ToList();
    }

    public IList<AudibleMediaItem> FetchPaginated(
      int pageNumber,
      int pageSize = 20)
    {
      return DBSet
        .Skip(pageNumber * pageSize)
        .Take(pageSize)
        .ToList();
    }

  }
}
