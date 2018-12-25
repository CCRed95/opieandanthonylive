using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain
{
  public class ShowMediaSegmentContentTag
  {
    public int ShowMediaContentTagID { get; set; }


    public int? ShowMediaEntryID { get; set; }
    [NotNull, ForeignKey("ShowMediaEntryID")]
    public virtual ShowMediaEntry ShowMediaEntry { get; set; }
    

    public long? SegmentTimeStart { get; set; }

    public long? SegmentTimeEnd { get; set; }

  }
}
