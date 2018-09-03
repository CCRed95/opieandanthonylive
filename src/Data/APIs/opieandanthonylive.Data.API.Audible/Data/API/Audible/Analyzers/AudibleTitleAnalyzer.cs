using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using opieandanthonylive.Data.Context;
using opieandanthonylive.Data.Domain;
using opieandanthonylive.Data.Domain.Audible;

namespace opieandanthonylive.Data.API.Audible.Analyzers
{
  public class AudibleTitleAnalyzer
  {
    public static List<Guest> guests
      = new List<Guest>();


    public static void Analyze(
      AudibleMediaItem metadata)
    {
      var airDate = metadata
        .ReleaseDate
        .ToString("MMMM d, yyyy");

      var airDate2 = metadata
        .ReleaseDate
        .ToString("MMMM DD, yyyy");

      var title = metadata.Title;

      const string opieAndAnthony = "Opie & Anthony";
      const string ronAndFez = "Ron & Fez";

      if (title.Contains(opieAndAnthony))
      {
        Debug.Write("[O&A] ");
        title = title
          .Replace(opieAndAnthony, "")
          .Trim(' ', ',');
      }
      else if (title.Contains(ronAndFez))
      {
        Debug.Write("[O&A] ");
        title = title
          .Replace(ronAndFez, "")
          .Trim(' ', ',');
      }
      else
      {
        Debug.Write("[???] ");
      }
      if (title.Contains(airDate))
      {
        Debug.Write(airDate);

        title = title
          .Replace(airDate, "")
          .Trim(' ', ',');
      }
      else if (title.Contains(airDate2))
      {
        Debug.Write(airDate);

        title = title
          .Replace(airDate, "")
          .Trim(' ', ',');
      }
      else
      {
      }
      var guestStr = title.Replace("and", ",");

      var guestsArr = guestStr.Split(',', ';');

      Debug.WriteLine("");

      var optionsBuilder = new DbContextOptionsBuilder<CoreContext>();
      optionsBuilder.UseSqlServer(
        "Server=(localdb)\\mssqllocaldb;Database=opieandanthonylive8;Trusted_Connection=true;MultipleActiveResultSets=true");

      using (var context = new CoreContext(optionsBuilder.Options))
      {
        foreach (var guestFullName in guestsArr)
        {
          var matchedGuest = guests
            .FirstOrDefault(t => t.FullName == guestFullName);

          if (matchedGuest == null)
          {
            matchedGuest = new Guest(guestFullName);
            context.Guests.Add(matchedGuest);

            context.SaveChanges();
          }
          //context.GuestAppearances
          //  .Add(new GuestAppearance(
          //    matchedGuest,
          //    new ShowMediaEntry()
          //    {

          //    }
          //    ))
          Debug.WriteLine($"    Guest Appearanace: {matchedGuest.GuestID}: {matchedGuest.FullName}");
        }
      }

      //yield return new ShowMetadata()
      //{

      //}
      //Debug.WriteLine(title);
    }

  }
}
