using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain
{
  public class ShowMediaEntry
  {
    public int ShowMediaEntryID { get; set; }

    public int? ShowID { get; set; }
    [CanBeNull, ForeignKey("ShowID")]
    public virtual Show Show { get; set; }

    public DateTime AirDate { get; set; }

    public string Title { get; set; }

    public string Url { get; set; }

    public virtual ICollection<GuestAppearance> GuestAppearances { get; set; }


    public ShowMediaEntry()
    {
      GuestAppearances = new HashSet<GuestAppearance>();
    }
  }
}
