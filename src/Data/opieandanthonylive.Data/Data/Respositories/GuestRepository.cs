using System.Collections.Generic;
using System.Linq;
using Ccr.Dnc.Data.EntityFrameworkCore;
using opieandanthonylive.Data.Context;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Respositories
{
  public interface IGuestRepository
  {
    Guest Fetch(int id);

    IList<Guest> FetchAll();

    Guest FetchByGuestName(string fullname);

    IList<Guest> FetchPaginated(
      int pageNumber,
      int pageSize = 20);
  }


  public class GuestRepository
    : Repository<Guest, int, CoreContext>,
      IGuestRepository
  {
    public GuestRepository(
      CoreContext context)
      : base(
          context)
    {
    }

    public Guest FetchByGuestName(
      string fullname)
    {
      return DBSet
        .Single(t => t.FullName == fullname);
    }

    public IList<Guest> FetchPaginated(
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
